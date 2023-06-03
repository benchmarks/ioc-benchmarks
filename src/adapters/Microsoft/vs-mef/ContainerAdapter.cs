using IoC.Adapter;
using CommonServiceLocator;
using Microsoft.VisualStudio.Composition;
using System.Reflection;
using System.Diagnostics;

namespace IoC.VisualStudio.Composition
{
    public class ContainerAdapter : Adapter.AdapterBase
    {
        public ContainerAdapter(AdapterInfo info)
            : base(info)
        {
        }

        public override IServiceLocator GetServiceLocator(IEnumerable<RegistrationDescriptor> registrations)
        {
            // Prepare part discovery to support both flavors of MEF attributes.
            var discovery = PartDiscovery.Combine(
                new AttributedPartDiscovery(Resolver.DefaultInstance), // "NuGet MEF" attributes (Microsoft.Composition)
                new AttributedPartDiscoveryV1(Resolver.DefaultInstance)); // ".NET MEF" attributes (System.ComponentModel.Composition)

            // Build up a catalog of MEF parts
            var catalog = ComposableCatalog.Create(Resolver.DefaultInstance)
                //.AddParts(await discovery.CreatePartsAsync(Assembly.GetExecutingAssembly()))
                .AddPart(discovery.CreatePart(typeof(ServiceLocator))!)
                .WithCompositionService(); // Makes an ICompositionService export available to MEF parts to import

            foreach (var registration in registrations)
            {
                var part = discovery.CreatePart(registration.ImplementationType ?? registration.ContractType)!;
                catalog = catalog.AddPart(part);
            }

            // Assemble the parts into a valid graph.
            var config = CompositionConfiguration.Create(catalog);

            // Prepare an ExportProvider factory based on this graph.
            var epf = config.CreateExportProviderFactory();

            // Create an export provider, which represents a unique container of values.
            // You can create as many of these as you want, but typically an app needs just one.
            var provider = epf.CreateExportProvider();
            
            return provider.GetExportedValue<IServiceLocator>();
        }
    }
}

using Autofac;
using FilesSizeByExtensions.FileExtensions;
using FilesSizeByExtensions.Formatting;
using FilesSizeByExtensions.SpaceCalculator;

public class Modules : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<Extensions>().As<IExtensions>();
        builder.RegisterType<FileSpaceCalculator>().As<IFileSpaceCalculator>();
        builder.RegisterType<Formatter>().As<IFormatter>();
    }
}
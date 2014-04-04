using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using NUnit.Framework;

[TestFixture]
public class Sample {

    [TestFixtureSetUp]
    public void Setup()
    {
        //if commented then all tests are working
        foreach (string dll in Directory.EnumerateFiles(AssemblyLocation.CurrentDirectory(), "*.resources.dll", SearchOption.AllDirectories))
        {
            File.Delete(dll);
        }
    }

    [Test]
    public void Run()
    {
        Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;

        string hello = CosturaInternalResourcesSample.Properties.Resources.SayHello;
        Debug.WriteLine(hello);
        Assert.That(hello, Is.EqualTo("Hello"));
    }


    [Test]
    public void Say_Hello_in_German_should_return_Hallo()
    {
        Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("de-DE");

        string hello = CosturaInternalResourcesSample.Properties.Resources.SayHello;
        Assert.That(hello, Is.EqualTo("Hallo"));
    }

    [Test]
    public void Say_Hello_in_French_should_return_Salut()
    {
        Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("fr-FR");

        string hello = CosturaInternalResourcesSample.Properties.Resources.SayHello;
        Assert.That(hello, Is.EqualTo("Salut"));
    }

    [Test]
    public void Say_Hello_in_Dutch_without_NL_resource_should_return_Hello()
    {
        Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("nl-NL");

        string hello = CosturaInternalResourcesSample.Properties.Resources.SayHello;
        Assert.That(hello, Is.EqualTo("Hello"));
    }
}


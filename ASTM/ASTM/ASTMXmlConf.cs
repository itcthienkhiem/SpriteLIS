/* 
  Licensed under the Apache License, Version 2.0
    
  http://www.apache.org/licenses/LICENSE-2.0
  */
using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace Xml2CSharp
{
    [XmlRoot(ElementName = "add")]
    public class Add
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "providerName")]
        public string ProviderName { get; set; }
        [XmlAttribute(AttributeName = "connectionString")]
        public string ConnectionString { get; set; }
        [XmlAttribute(AttributeName = "key")]
        public string Key { get; set; }
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "connectionStrings")]
    public class ConnectionStrings
    {
        [XmlElement(ElementName = "add")]
        public Add Add { get; set; }
    }

    [XmlRoot(ElementName = "config")]
    public class Config
    {
        [XmlElement(ElementName = "add")]
        public List<Add> Add { get; set; }
    }

    [XmlRoot(ElementName = "appSettings")]
    public class AppSettings
    {
        [XmlElement(ElementName = "add")]
        public List<Add> Add { get; set; }
    }

    [XmlRoot(ElementName = "supportedRuntime")]
    public class SupportedRuntime
    {
        [XmlAttribute(AttributeName = "version")]
        public string Version { get; set; }
        [XmlAttribute(AttributeName = "sku")]
        public string Sku { get; set; }
    }

    [XmlRoot(ElementName = "startup")]
    public class Startup
    {
        [XmlElement(ElementName = "supportedRuntime")]
        public SupportedRuntime SupportedRuntime { get; set; }
    }

    [XmlRoot(ElementName = "configuration")]
    public class Configuration
    {
        [XmlElement(ElementName = "connectionStrings")]
        public ConnectionStrings ConnectionStrings { get; set; }
        [XmlElement(ElementName = "config")]
        public Config Config { get; set; }
        [XmlElement(ElementName = "appSettings")]
        public List<AppSettings> AppSettings { get; set; }
        [XmlElement(ElementName = "startup")]
        public Startup Startup { get; set; }
    }

}

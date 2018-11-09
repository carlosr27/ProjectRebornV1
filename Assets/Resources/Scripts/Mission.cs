using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

public class Mission
{
    [XmlAttribute("name")]
    public int name;

    [XmlElement("Item")]
    public string item;

    [XmlElement("Amount")]
    public int amount;

    [XmlElement("Item2")]
    public string item2;

    [XmlElement("Amount2")]
    public int amount2;

    [XmlElement("Reward")]
    public int reward;
}

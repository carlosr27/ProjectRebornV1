using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;


[XmlRoot("MissionCollection")]
public class MissionContainer
{
    [XmlArray("Missions")]
    [XmlArrayItem("Mission")]
    

    public List<Mission> missions = new List<Mission>();

    public static MissionContainer Load(string path2)
    {
        TextAsset _xml = Resources.Load<TextAsset>(path2);

        XmlSerializer serializer = new XmlSerializer(typeof(MissionContainer));

        StringReader reader = new StringReader(_xml.text);

        MissionContainer missions = serializer.Deserialize(reader) as MissionContainer;

        reader.Close();

        return missions;
    }


}

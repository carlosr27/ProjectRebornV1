using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;


[XmlRoot("ItemCollection")]
public class ItemContainer {

    [XmlArray("Itens")]
    [XmlArrayItem("Item")]


    public List<Item> itens = new List<Item>();

    public static ItemContainer Load(string path)
    {
        TextAsset _xml = Resources.Load<TextAsset>(path);

        XmlSerializer serializer = new XmlSerializer(typeof(ItemContainer));

        StringReader reader = new StringReader(_xml.text);

        ItemContainer itens = serializer.Deserialize(reader) as ItemContainer;

        reader.Close();

        return itens;
    }



    /*public static void Main()
    {
        Item novos = new Item();
        novos.name = "Uranio";
        novos.amount = 1;
        Serialize(novos);
    }
    static public void Serialize(Item novos)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Item));
        using (TextWriter writer = new StreamWriter(@"C:/Users/CarlosR27/Documents/Function Start/ProjectReborN(0.008)/ProjectReborN/Project Reborn/Assets/Resources/XML/item.xml"))
        {
            serializer.Serialize(writer, novos);
        }
    }
    / FUNCIONA, MAS APAGA TUDO O QUE ESTA ESCRITO E AINDA ALTERA O CODIGO
    public void Main()
    {
        List<Item> AdNovos = new List<Item>();
        Item novos = new Item();
        novos.name = "Uranio";
        novos.amount = 1;

        AdNovos.Add(novos);

        Serialize(AdNovos);
    }

    public void Main(string name, int amount)
    {
        Item novos = new Item();
        novos.name = name;
        novos.amount = amount;

        itens.Add(novos);

        Serialize(itens);
    }

    public void Serialize(List<Item> list)
    {

        XmlSerializer serializer = new XmlSerializer(typeof(List<Item>));
        using (TextWriter writer = new StreamWriter(@"C:/Users/CarlosR27/Documents/Function Start/ProjectReborN(0.008)/ProjectReborN/Project Reborn/Assets/Resources/XML/item.xml"))
        {
            serializer.Serialize(writer, list);

        }
    }*/
}

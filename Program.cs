using System.Xml;

using (XmlReader reader = XmlReader.Create(@"../../../xml/sma_gentext.xml"))
{
    string outputPath = @"../../../txt/";

    while (reader.Read())
    {
        if (reader.IsStartElement())
        {
                if (reader.Name == "trans-unit")
                {
                    while (reader.MoveToNextAttribute())
                    {
                        if (reader.Name == "id" && reader.Value == "42007")
                        {
                            reader.MoveToElement();
                            reader.ReadToDescendant("target");
                            string target = reader.ReadElementContentAsString();
                            Console.WriteLine("Target value: {0}", target);
                            File.WriteAllText(outputPath + "output.txt", target);
                        }
                    }
                    reader.MoveToElement();
                }
                reader.Read();           
        }
    }

    Console.WriteLine("\nPress any button to exit.");
    Console.ReadKey();
}
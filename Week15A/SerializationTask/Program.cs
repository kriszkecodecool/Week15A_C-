using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SerializationTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person("Krisztián", 1994, 22);
            Console.WriteLine(p1);
            Serialize(p1);
            Console.ReadLine();
            Person p2 = Deserialize();
            Console.WriteLine(p2);
        }
        private static void Serialize(Person sp)
        {
            FileStream fs = new FileStream("Person.Dat", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, sp);
            fs.Close();
        }

        private static Person Deserialize()
        {
            Person p2 = new Person();
            FileStream fs = new FileStream("Person.Dat", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            p2 = (Person)bf.Deserialize(fs);
            fs.Close();
            return p2;
        }
    }
}

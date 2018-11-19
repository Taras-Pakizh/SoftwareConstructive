using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace GameLogic
{
    [Serializable]
    public class MementoCareTaker
    {
        public List<MazeMemento> mementos;

        public static readonly string SavePath = Environment.CurrentDirectory + @"\Resources\Saves\";
        public static readonly string SaveName = "Mementos.dat";

        public MementoCareTaker()
        { 
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(SavePath + SaveName, FileMode.OpenOrCreate))
            {
                if (fs.Length != 0)
                    mementos = (List<MazeMemento>)formatter.Deserialize(fs);
                else mementos = new List<MazeMemento>();
            }
        }
    }
}

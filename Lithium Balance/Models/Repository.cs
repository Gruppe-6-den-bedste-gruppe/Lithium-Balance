using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lithium_Balance.Views;
using Lithium_Balance.Models;
using System.IO;

namespace Lithium_Balance.Models
{
    public abstract class Repository<T> where T : IPersistable, new()
    {
        public List<T> List { get; protected set; }
        public static Repository<T> Instance { get; private set; }
        private readonly string path;
        public Repository(string path)
        {
            this.path = path;
            Instance = this;
            Load();
        }

        public void Add(T obj)
        {
            List.Add(obj);
            Save();
        }

        public void Update(T obj)
        {
            if (obj != null)
                Save();
        }

        public void Delete(T obj)
        {
            List.Remove(obj);
            Save();
        }

        protected virtual void Load()
        {
            if (!File.Exists(path))
                File.Create(path).Close();
            using StreamReader reader = new(path);
            List = new();

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                T p = new();
                p.Parse(line);
                List.Add(p);
            }
        }

        protected virtual void Save()
        {
            using StreamWriter writer = new(path);
            for (int i = 0; i < List.Count; i++)
            {
                writer.WriteLine(List[i].Format());
            }
        }        
    }
}

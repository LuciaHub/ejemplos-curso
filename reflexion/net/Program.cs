using System;
using System.Reflection;
using System.Text;

namespace reflexion
{
    class Program
    {
        static void Main(string[] args)
        {
            Curso curso = new Curso(4, "Programación 4");
            Type cursoType = curso.GetType();

            Repository<Curso, int> cursoRepository = new Repository<Curso, int>();
            cursoRepository.create(curso);
        }
    }

    class Curso
    {
        public int Id;
        public string Nombre;

        public Curso(int id, string nombre)
        {
            this.Id = id;
            this.Nombre = nombre;
        }
    }

    interface ICrudRepository<T, ID>
    {
        void create(T t);
        void read(ID id);
        void readAll();
        void delete(T t);

    }

    class Repository<T, ID> : ICrudRepository<T, ID>
    {
        public void create(T t)
        {
            Type type = t.GetType();
            string table = type.Name;
            FieldInfo[] fields = type.GetFields();
            StringBuilder query = new StringBuilder();
            query
                .Append("INSERT INTO ")
                .Append(table)
                .Append("(");
            for (int i = 0; i < fields.Length; i++)
            {
                query.Append(fields[i].Name);
                if (i != fields.Length - 1)
                {
                    query.Append(", ");
                }
            }
            query.Append(") VALUES (");
            for (int i = 0; i < fields.Length; i++)
            {
                FieldInfo field = fields[i];
                string fieldType = field.FieldType.FullName;
                if (fieldType == "System.String")
                {
                    query.Append("'");
                }
                query.Append(field.GetValue(t));
                if (fieldType == "System.String")
                {
                    query.Append("'");
                }
                if (i != fields.Length - 1)
                {
                    query.Append(", ");
                }
            }
            query.Append(")");
            Console.WriteLine(query.ToString());
        }

        public void delete(T t)
        {
            throw new NotImplementedException();
        }

        public void read(ID id)
        {
            throw new NotImplementedException();
        }

        public void readAll()
        {
            throw new NotImplementedException();
        }
    }
}

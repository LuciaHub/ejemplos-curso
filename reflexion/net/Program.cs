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

            Repository<Curso> cursoRepository = new Repository<Curso>();
            cursoRepository.add(curso);
        }
    }

    class Curso {
        public int Id;
        public string Nombre;

        public Curso(int id, string nombre){
            this.Id = id;
            this.Nombre = nombre;
        }
    }

    class Repository<T> {
        public void add(T t){
            Type type = t.GetType();
            string table = type.Name;
            FieldInfo[] fields = type.GetFields();
            StringBuilder query = new StringBuilder();
            query
                .Append("INSERT INTO ")
                .Append(table)
                .Append("(");
            for(int i=0; i<fields.Length; i++) {
                query.Append(fields[i].Name);
                if(i != fields.Length - 1) {
                    query.Append(", ");
                }
            }
            query.Append(") VALUES (");
            for(int i=0; i<fields.Length; i++){
                FieldInfo field = fields[i];
                string fieldType = field.FieldType.FullName;
                if(fieldType == "System.String"){
                    query.Append("'");
                }
                query.Append(field.GetValue(t));
                 if(fieldType == "System.String"){
                    query.Append("'");
                }
                if(i != fields.Length - 1){
                    query.Append(", ");
                }
            }
            query.Append(")");
            Console.WriteLine(query.ToString());
        }
    }
}

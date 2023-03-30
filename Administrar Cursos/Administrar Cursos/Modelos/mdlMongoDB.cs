using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administrar_Cursos.Modelos
{
    public static class mdlMongoDB
    {
        public static void Insertar(mdlGrupos mdlMetodosMongoDB)
        {
            try
            {
                MongoClient oClient = new MongoClient("mongodb://localhost:27017");

                var oDatabase = oClient.GetDatabase("Cursos");

                var coleccion = oDatabase.GetCollection<mdlGrupos>("datos");
                coleccion.InsertOne(mdlMetodosMongoDB);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

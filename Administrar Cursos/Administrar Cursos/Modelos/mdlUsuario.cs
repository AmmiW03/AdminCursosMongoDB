using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administrar_Cursos.Modelos
{
    public class mdlUsuario
    {
        [BsonElement]
        public String sNombreCompleto { get; set; }
        [BsonElement]
        public String sFechaNac { get; set; }
        [BsonElement]
        public String sDireccion { get; set; }
        [BsonElement]
        public String sCP { get; set; }
        [BsonElement]
        public String sTelefono { get; set; }
        [BsonElement]
        public String sCorreo { get; set; }
        [BsonElement]
        public String sFechaAlta { get; set; }
        [BsonElement]
        public List<mdlCurso> lstCursos = new List<mdlCurso>();
    }
}

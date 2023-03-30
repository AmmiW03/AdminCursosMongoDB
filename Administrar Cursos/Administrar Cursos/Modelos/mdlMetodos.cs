using MongoDB.Bson;
using MongoDB.Driver.Linq;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administrar_Cursos.Modelos
{
    public class mdlMetodos
    {
        public static void Obtener()
        {
            try
            {
                string fileName = @"D:\Recursos\AsLogic\Ejercicio Migracion\Excel\Ejemplo.xlsx";

                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);

                IWorkbook workbook = new XSSFWorkbook(fs);

                ISheet sheet = workbook.GetSheetAt(0);

                DataFormatter dataf = new();
                

                if (sheet != null)
                {
                    List<mdlGrupos> lstGrupos = new List<mdlGrupos>();
                    
                    for (int i = 1; i < sheet.LastRowNum; i++)
                    {
                        IRow curRow = sheet.GetRow(i);
                        bool bGrupo = true;
                        
                        if(curRow != null)
                        {
                        for (int j = 0; j < lstGrupos.Count; j++)
                        {
                            if (dataf.FormatCellValue(curRow.GetCell(7)) == lstGrupos[j].sNombre)
                            {
                                bGrupo = false;
                            }
                        }
                        if (bGrupo)
                        {
                            mdlGrupos oGrupo = new mdlGrupos();
                            oGrupo.sNombre = dataf.FormatCellValue(curRow.GetCell(7));
                            lstGrupos.Add(oGrupo);
                        }


                        mdlUsuario oUsuario = new mdlUsuario();

                        oUsuario.sNombreCompleto = dataf.FormatCellValue(curRow.GetCell(0));

                        oUsuario.sFechaNac = dataf.FormatCellValue(curRow.GetCell(1));

                        oUsuario.sDireccion = dataf.FormatCellValue(curRow.GetCell(2));
                        oUsuario.sCP = dataf.FormatCellValue(curRow.GetCell(3));
                        oUsuario.sTelefono = dataf.FormatCellValue(curRow.GetCell(4));
                        oUsuario.sCorreo = dataf.FormatCellValue(curRow.GetCell(5));

                        oUsuario.sFechaAlta = dataf.FormatCellValue(curRow.GetCell(6));

                        for (int j = 8; j < curRow.Cells.Count - 1; j = j + 2)
                        {
                            mdlCurso oCurso = new mdlCurso();

                            oCurso.sNombre = dataf.FormatCellValue(curRow.GetCell(j));
                            oCurso.sFecha = dataf.FormatCellValue(curRow.GetCell(j + 1));

                            oUsuario.lstCursos.Add(oCurso);
                        }

                        lstGrupos.Where(D => D.sNombre == dataf.FormatCellValue(curRow.GetCell(7))).FirstOrDefault().lstUsuarios.Add(oUsuario);
                        }
                        
                    }
                    for (int i = 0; i < lstGrupos.Count; i++)
                    {
                        if(lstGrupos[i].sNombre != "")
                        {
                            mdlMongoDB.Insertar(lstGrupos[i]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}

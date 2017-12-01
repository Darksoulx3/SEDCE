using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SEDCE
{
    public class Notas
    {
        //Notas importantes xd

        //Procedure de reporte :v

//       ALTER PROCEDURE [dbo].[MATRICULA_COMPLETA_CARRERA_ESPECIFICA] 
//@CARRERA varchar(255)
//AS
//SELECT sexo AS 'Genero', Años AS 'Edad', nombre_carrera AS 'Carrera', 
//       semestre as'Semestre', competencias as 'Competencia',
//       null as 'Extanjero',REPLACE(lengua_indigena,'NULL','N') as 'Lengua_Indigena',
//       REPLACE(discapacidad,'NULL','N') as 'Discapacidad' ,promediodecalificacion as 'Promedio',
//       Count(no_de_control) AS Cantidad
//FROM ALUMNO INNER JOIN carrera 
//ON ALUMNO.id_carrera = carrera.id_carrera 
//WHERE nombre_carrera = @CARRERA
//Group by sexo, AÑOS, nombre_carrera,semestre,COMPETENCIAs, Lengua_Indigena, Discapacidad, PromedioDecalificacion
//Order by carrera

//        ALTER PROCEDURE [dbo].[MATRICULA_COMPLETA] AS
//SELECT sexo AS 'Genero', Años AS 'Edad', nombre_carrera AS 'Carrera', 
//       semestre as'Semestre', competencias as 'Competencia',
//       null as 'Extanjero',REPLACE(lengua_indigena,'NULL','N') as 'Lengua_Indigena',
//       REPLACE(discapacidad,'NULL','N') as 'Discapacidad' ,promediodecalificacion as 'Promedio',
//       Count(no_de_control) AS Cantidad
//FROM ALUMNO INNER JOIN carrera 
//ON ALUMNO.id_carrera = carrera.id_carrera 
//Group by sexo, AÑOS, nombre_carrera,semestre,COMPETENCIAs, Lengua_Indigena, Discapacidad, PromedioDecalificacion
//Order by carrera

    }
}
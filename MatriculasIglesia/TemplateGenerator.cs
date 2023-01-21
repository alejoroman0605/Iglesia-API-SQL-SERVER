using MatriculasIglesia.Dtos.Proyectos;
using System.Text;

namespace MatriculasIglesia
{
    public class TemplateGenerator
    {
        public static string GetHTMLString(ProyectoDto proyDto)
        {

            var sb = new StringBuilder();
            //inicio
            sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>");

            // detalles del proyecto
            sb.AppendFormat(@"<br />
	<h3>Proyecto: <span class='details'>{0}</span></h3>
	<h3>Administrador: <span class='details'>{1}</span></h3>
	<h3>Coordinador: <span class='details'>{2}</span></h3>
	<h3>Capacidad: <span class='details'>{3}</span></h3>
    <h3>Abiertas: <span class='details'>{4}</span></h3>
	<h3>Duración: <span class='details'>{5} a {6}</span></h3>
	<h3>Iglesia: <span class='details'>{7}</span></h3>
</div>",
                proyDto.Nombre, proyDto.Administrador, proyDto.Coordinador, proyDto.Capacidad,
                proyDto.Capacidad - proyDto.Matriculas.Count(m => m.IsMatriculado),
                proyDto.Inicio, proyDto.Final, proyDto.Iglesia);

            // matriculados
            sb.AppendFormat(@"<div class='header'><h1>Matriculados ({0})</h1></div>", proyDto.Matriculas.Count(m => m.IsMatriculado));
            int no = 0;
            foreach (var mat in proyDto.Matriculas.Where(m => m.IsMatriculado))
            {
                if (no == 0)
                {
                    sb.Append(@"<table align='center'>
                                    <tr>
                                        <th>No</th>
                                        <th>Niño</th>
                                        <th>Responsable</th>
                                        <th>Fecha</th>
                                        <th>Horario</th>
                                    </tr>");
                }
                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                    <td>{4}</td>
                                  </tr>", ++no, mat.Nino, mat.Responsable, mat.Fecha, mat.Horario);
            }

            sb.Append(@"</table>");

            // second table
            sb.AppendFormat(@"<div class='header'><h1>Lista de espera ({0})</h1></div>", proyDto.Matriculas.Count(m => ! m.IsMatriculado));
            no = 0;
            foreach (var mat in proyDto.Matriculas.Where(m => !m.IsMatriculado))
            {
                if (no == 0)
                {
                    sb.Append(@"<table align='center'>
                                    <tr>
                                        <th>No</th>
                                        <th>Niño</th>
                                        <th>Responsable</th>
                                        <th>Fecha</th>
                                        <th>Horario</th>
                                    </tr>");
                }
                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                    <td>{4}</td>
                                  </tr>", ++no, mat.Nino, mat.Responsable, mat.Fecha, mat.Horario);

            }

            sb.Append(@"</table>");

            // final
            sb.Append(@"</body>
                        </html>");

            return sb.ToString();
        }
    }
}

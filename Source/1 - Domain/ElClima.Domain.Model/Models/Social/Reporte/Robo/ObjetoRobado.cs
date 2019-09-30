using ElClima.Domain.Core.Entities;
using ElClima.Domain.Model.Enums.Social.Entidad;
using ElClima.Domain.Model.Enums.Social.Reporte.Robo;

namespace ElClima.Domain.Model.Models.Social.Reporte.Robo
{
    public class ObjetoRobado : BaseEntity
    {
        public ObjetoRobado()
        {

        }

        public ObjetoRobado(ObjetoRobadoEnum tipoObjetoRobado)
        {
            id = (int)tipoObjetoRobado;
            detalle = tipoObjetoRobado.GetDescription();
        }

        public string detalle { get; set; }

        public override string ToString()
        {
            return $"{detalle} ({id})";
        }
    }
}

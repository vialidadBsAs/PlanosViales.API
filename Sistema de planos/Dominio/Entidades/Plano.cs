﻿namespace Sistema_de_planos.Dominio.Entidades
{
    public partial class Plano
    {
        public int Id { get; set; }
        public int NumPlano { get; set; }
        public string Propietario { get; set; } = string.Empty;
        public double Arancel { get; set; }
        public DateTime FechaOriginal { get; set; }
        public int EstadoId { get; set; }
        public int PartidoId { get; set; }
        public Estado Estado { get; set; }
        public Partido Partido { get; set; }
        public List<Historico> Historicos { get; set; }
    }
}

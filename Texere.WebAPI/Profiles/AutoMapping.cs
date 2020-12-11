using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Texere.Model;
using Texere.WebAPI.DTOs;

namespace Texere.WebAPI
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<LineasPedido, LineasPedidoDTO>()
                .ForMember(dest =>
                    dest.LineaPedidoId,
                    opt => opt.MapFrom(src => src.LineaPedidoId))
                .ForMember(dest =>
                    dest.Accesorio,
                    opt => opt.MapFrom(src => src.Accesorio.DescAccesorio))
                .ForMember(dest =>
                    dest.Cantidad,
                    opt => opt.MapFrom(src => src.Cantidad))
                .ForMember(dest =>
                    dest.Estado,
                    opt => opt.MapFrom(src => src.EstadoId))
                .ForMember(dest =>
                    dest.Material,
                    opt => opt.MapFrom(src => src.Material.DescMaterial))
                .ForMember(dest =>
                    dest.Modelo,
                    opt => opt.MapFrom(src => src.Modelo.DescModelo))
                .ForMember(dest =>
                    dest.Talle,
                    opt => opt.MapFrom(src => src.Talle.DescTalle))
                .ForMember(dest =>
                    dest.AccesorioId,
                    opt => opt.MapFrom(src => src.AccesorioId));

            CreateMap<Pedidos, PedidosDTO>()
                .ForMember(dest =>
                    dest.PedidoId,
                    opt => opt.MapFrom(src => src.PedidoId))
                .ForMember(dest =>
                    dest.EstadoId,
                    opt => opt.MapFrom(src => src.Estado.EstadoId))
                .ForMember(dest =>
                    dest.Estado,
                    opt => opt.MapFrom(src => src.Estado.Descripcion))
                .ForMember(dest =>
                    dest.Fecha,
                    opt => opt.MapFrom(src => src.Fecha))
                .ForMember(dest =>
                    dest.ClienteDni,
                    opt => opt.MapFrom(src => src.Cliente.DniCuit))
                .ForMember(dest =>
                    dest.ClienteNombre,
                    opt => opt.MapFrom(src => src.Cliente.NombreApellido));
        }
    }
}

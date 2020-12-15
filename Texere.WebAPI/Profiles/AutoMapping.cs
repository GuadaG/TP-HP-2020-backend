﻿using System;
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
                    dest.Estado,
                    opt => opt.MapFrom(src => src.Estado.Descripcion))
                .ForMember(dest =>
                    dest.Fecha,
                    opt => opt.MapFrom(src => src.Fecha));

            CreateMap<Modelos, ModelosDTO>()
                .ForMember(dest =>
                    dest.ModeloId,
                    opt => opt.MapFrom(src => src.ModeloId))
                .ForMember(dest =>
                    dest.DescModelo,
                    opt => opt.MapFrom(src => src.DescModelo))
                .ForMember(dest =>
                    dest.Imagen,
                    opt => opt.MapFrom(src => src.Imagen))
                .ForMember(dest =>
                    dest.ColorBaseId,
                    opt => opt.MapFrom(src => src.ColorBaseId))
                .ForMember(dest =>
                    dest.Instituciones,
                    opt => opt.MapFrom(src => src.Instituciones.Select(i => i.InstitucionId)))
                .ForMember(dest =>
                    dest.Colores,
                    opt => opt.MapFrom(src => src.ColoresModelos.Select(i => i.ColorId)));

            CreateMap<Accesorios, AccesoriosDTO>()
                .ForMember(dest =>
                    dest.AccesorioId,
                    opt => opt.MapFrom(src => src.AccesorioId))
                .ForMember(dest =>
                    dest.DescAccesorio,
                    opt => opt.MapFrom(src => src.DescAccesorio))
                .ForMember(dest =>
                    dest.TieneTalle,
                    opt => opt.MapFrom(src => src.TieneTalle))
                .ForMember(dest =>
                    dest.Precio,
                    opt => opt.MapFrom(src => src.HistoricoPrecio.Where(x => x.FechaVigencia <= DateTime.Now).OrderByDescending(x => x.FechaVigencia).FirstOrDefault().Valor));
        }
    }
}

﻿
namespace ItlaTV.Application.Dtos.Serie
{
    public class SerieUpdateDto : SerieDto
    {
        public int SerieId { get; set; }

        public required string ImagenPath { get; set; }
    }
}

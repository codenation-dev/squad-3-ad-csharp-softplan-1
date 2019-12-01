﻿using System;

namespace ErrorCenter.Domain.Models.Base
{
    public class ModelBase
    {
        public Guid? Id { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }
        public bool Ativo { get; set; }

        public ModelBase()
        {
            Id = Guid.NewGuid();
        }
    }
}

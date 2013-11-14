﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Clinica_Frba.Cancelar_Atencion
{
    public class FormCancelarFactory
    {
        public static BaseCancelarAtencion abrirVentanaCancelaciones(Form padre, string rol) 
        {
            switch (rol) 
            {
                case "Administrativo": return new AdministradorCancelar(padre);

                case "Profesional": return new ProfesionalCancelar(padre);

                case "Afiliado": return new AfiliadoCancelar(padre);

            }

            throw new Exception("String del factory para cancelacion invalido");
        }
    }
}

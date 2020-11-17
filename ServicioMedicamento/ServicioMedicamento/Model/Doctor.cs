//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServicioMedicamento.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Doctor
    {
        public int IIDDOCTOR { get; set; }
        public string NOMBRE { get; set; }
        public string APPATERNO { get; set; }
        public string APMATERNO { get; set; }
        public Nullable<int> IIDCLINICA { get; set; }
        public Nullable<int> IIDESPECIALIDAD { get; set; }
        public string EMAIL { get; set; }
        public string TELEFONOCELULAR { get; set; }
        public Nullable<int> IIDSEXO { get; set; }
        public Nullable<decimal> SUELDO { get; set; }
        public Nullable<System.DateTime> FECHACONTRATO { get; set; }
        public Nullable<int> BHABILITADO { get; set; }
        public string NOMBREARCHIVO { get; set; }
        public string ARCHIVO { get; set; }
    
        public virtual Clinica Clinica { get; set; }
        public virtual Sexo Sexo { get; set; }
        public virtual Especialidad Especialidad { get; set; }
    }
}

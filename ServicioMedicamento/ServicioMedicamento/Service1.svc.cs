using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ServicioMedicamento.Models;
using ServicioMedicamento.Model;

namespace ServicioMedicamento
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        MedicoEntities db;

        public Service1()
        {
            db = new MedicoEntities();
        }

        int IService1.eliminarMedicamento(int idMedicamento)
        {
            int rpta = 0;

            try
            {
                Medicamento oMedicamento = db.Medicamento.Where(p => p.IIDMEDICAMENTO == idMedicamento).First();
                oMedicamento.BHABILITADO = 0;
                db.SaveChanges();
                return rpta = 1;
            }
            catch (Exception ex)
            {
                rpta = 0;
            }

            return rpta;
        }

        List<FormaFarmaceuticaModel> IService1.listFormaFarmaceutica()
        {
            List<FormaFarmaceuticaModel> listModel = new List<FormaFarmaceuticaModel>();

            try
            {
                listModel = (from p in db.FormaFarmaceutica
                             where p.BHABILITADO == 1
                             select new FormaFarmaceuticaModel
                             {
                                 IdFormaFarmaceutica = p.IIDFORMAFARMACEUTICA,
                                 nombreFormaFarmaceutica = p.NOMBRE
                             }).ToList();
            }
            catch (Exception)
            {
                listModel = null;
            }

            return listModel;
        }

        List<MedicamentoModel> IService1.listMedicamentos()
        {
            List<MedicamentoModel> listModel = new List<MedicamentoModel>();
            try
            {
                listModel = (from m in db.Medicamento
                             join ff in db.FormaFarmaceutica on m.IIDFORMAFARMACEUTICA equals ff.IIDFORMAFARMACEUTICA
                             where m.BHABILITADO == 1
                             select new MedicamentoModel
                             {
                                 IdMedicamento = m.IIDMEDICAMENTO,
                                 Nombre = m.NOMBRE,
                                 Precio = (decimal) m.PRECIO,
                                 NombreFormaFarmaceutica = ff.NOMBRE,
                                 Concentracion = m.CONCENTRACION,
                                 stock = (int) m.STOCK,
                                 Presentacion = m.PRESENTACION
                             }).ToList();
            }
            catch (Exception ex)
            {
                listModel = null;
            }
            return listModel;
        }

        MedicamentoModel IService1.recuperarMedicamento(int idMedicamento)
        {
            MedicamentoModel model = new MedicamentoModel();
            try
            {
                Medicamento oMedicamento = db.Medicamento.Where(p => p.IIDMEDICAMENTO == idMedicamento).First();
                model.IdMedicamento = oMedicamento.IIDMEDICAMENTO;
                model.idFormaFarmaceutica = (int) oMedicamento.IIDFORMAFARMACEUTICA;
                model.Nombre = oMedicamento.NOMBRE;
                model.Precio = (decimal) oMedicamento.PRECIO;
                model.stock = (int) oMedicamento.STOCK;
                model.Concentracion = oMedicamento.CONCENTRACION;
                model.Presentacion = oMedicamento.PRESENTACION;

            }
            catch (Exception ex)
            {
                model=null;

            }

            return model;
        }

        int IService1.registrarYActualizarMedicamento(MedicamentoModel model)
        {

            int rpta = 0;

            try
            {
                if (model.IdMedicamento == 0)
                {
                    //Registrar 
                    Medicamento oMedicamento = new Medicamento();
                    oMedicamento.NOMBRE = model.Nombre;
                    oMedicamento.PRECIO = model.Precio;
                    oMedicamento.STOCK = model.stock;
                    oMedicamento.IIDFORMAFARMACEUTICA = model.idFormaFarmaceutica;
                    oMedicamento.CONCENTRACION = model.Concentracion;
                    oMedicamento.PRESENTACION = model.Presentacion;
                    oMedicamento.BHABILITADO = 1;
                    db.Medicamento.Add(oMedicamento);
                    db.SaveChanges();
                    rpta = 1;
                }
                else
                {
                    //Editar
                    Medicamento oMedicamento = db.Medicamento.Where(p => p.IIDMEDICAMENTO == model.IdMedicamento).First();
                    oMedicamento.IIDMEDICAMENTO = model.IdMedicamento;
                    oMedicamento.NOMBRE = model.Nombre;
                    oMedicamento.PRECIO = model.Precio;
                    oMedicamento.STOCK = model.stock;
                    oMedicamento.IIDFORMAFARMACEUTICA = model.idFormaFarmaceutica;
                    oMedicamento.CONCENTRACION = model.Concentracion;
                    oMedicamento.PRESENTACION = model.Presentacion;
                    db.SaveChanges();
                    rpta = 1;
                }
            }
            catch (Exception ex)
            {
                rpta = 0;
            }

            return rpta;
        }
    }
}

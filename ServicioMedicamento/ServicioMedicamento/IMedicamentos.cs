using ServicioMedicamento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServicioMedicamento
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IMedicamentos
    {
        //Listado de medicamentos
        [OperationContract]
        List<MedicamentoModel> listMedicamentos();

        //Lista forma farmaceutica
        List<FormaFarmaceuticaModel> listFormaFarmaceutica();

        //Recuperar medicamento
        MedicamentoModel recuperarMedicamento(int idMedicamento);

        //Agregar y editar medicamentto
        int registrarYActualizarMedicamento(MedicamentoModel medicamento);

        //Eliminar medicamento
        int eliminarMedicamento(int idMedicamento);

        // TODO: agregue aquí sus operaciones de servicio
    }


    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
}

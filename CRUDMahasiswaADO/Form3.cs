using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace CRUDMahasiswaADO
{
    public partial class Form3 : Form
    {
        static readonly string connectionString =
            "Data Source=DIAN\\NAZARIN;Initial Catalog=DBAkademikADO;Integrated Security=True";

        readonly SqlConnection conn = new SqlConnection(connectionString);
      

        // Sesuaikan dengan nama file .rpt Anda = LaporanMahasiswa
        readonly CrystalReport2 laporanMahasiswa = new CrystalReport2();
        CrystalReport2 listMahasiswa = new CrystalReport2();

        string prodi { get; set; }
        DateTime tglmasuk { get; set; }

        public Form3(string Prodi, DateTime TglMasuk)
        {
            InitializeComponent();

            prodi = Prodi;
            tglmasuk = TglMasuk;

            try
            {
                DAL dbLogic = new DAL();
                DataTable dtMahasiswa = dbLogic.getDataRekap(prodi, tglmasuk);

                listMahasiswa.SetDataSource(dtMahasiswa);
                crystalReportViewer2.ReportSource = listMahasiswa;
                crystalReportViewer2.Refresh();
            }
            catch (Exception ex)
            {
                //simpanLog(ex.Message);
                MessageBox.Show("Gagal load data: " + ex.Message);
            }
        }


    }
}
using Entities.Concrete;
using Service.Concrete;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface
{


    public partial class PersonelIslemler : Form
    {
        IKitapService kitapService;  //yeni nesne
        IOgrenciService ogrenciService;  //yeni nesne
        IEmanetService emanetService;  //yeni nesne
        List<Emanet> emanetler;    //yeni nesne
        List<Ogrenci> ogrenciler;  //yeni nesne

        public PersonelIslemler()
        {
            InitializeComponent();
            ogrenciService = new OgrenciService();  //yeni nesne
            kitapService = new KitapService();  //yeni nesne
            emanetService = new EmanetService();  //yeni nesne
            DataGridViewFill();  //DataGridFill'i tanımladık
        }

        

        private void DataGridViewFill()
        {
            dataGridView1.DataSource = ogrenciler; ogrenciler = ogrenciService.listele();  //öğrencileri dataGrid'de listeledik
            dataGridView1.DataSource = ogrenciler; 
            dgvKitap.DataSource = kitapService.listele();  //kitapları listesini dataGrid'e atamak için
            dGwEmanet.DataSource = emanetService.listele();  //emanet listelemek dataGrid'e atamak için
            emanetler = emanetService.listele(); //emanetService'ten emanetleri çağırıyruz.
        }

        private void btnOgrEkle_Click(object sender, EventArgs e)
        {
            Entities.Concrete.Ogrenci ogrenci = new Entities.Concrete.Ogrenci();  //yeni nesne
            ogrenci.Ad = txtAd.Text; //text'e adı yazdırabilmek için
            ogrenci.Soyad = txtSoyad.Text;  //text'e soyadı yazdırabilmek için
            ogrenci.Tel = txtTel.Text; //text'e teli yazdırabilmek için
            ogrenci.Eposta = txtEposta.Text;  //text'e epostayı yazdırabilmek için
            ogrenci.Adres = txtAdres.Text;  //text'e adresi yazdırabilmek için
            ogrenci.Sifre = txtSifre.Text;  //text'e şifreyi yazdırabilmek için
            ogrenci.Tc = txtTc.Text;  //text'e tc'yi yazdırabilmek için
            ogrenciService.ekle(ogrenci);  //ekliyoruz
            MessageBox.Show("Başarıyla Eklendi");  //eklendiğine dair messageBox ile mesaj veriyoruz.
            DataGridViewFill();  //dataGrid'i burda çağırıyoruz, görebilmek için
        }

        private void btnOgrSil_Click(object sender, EventArgs e)
        {
            Entities.Concrete.Ogrenci ogrenci = new Entities.Concrete.Ogrenci();  //yeni nesne
            int id = Convert.ToInt32(txtId.Text);  //Id'ye göre silme işlemi sağlıyoruz.
            ogrenciService.sil(id);  //siliyoruz
            MessageBox.Show("Silindi");  //silindiğine dair messageBox'a mesaj atıyoruz.
            DataGridViewFill();  //dataGrid'i burda çağırıyoruz, görebilmek için
        }

        private void btnOgrGuncelle_Click(object sender, EventArgs e)
        {
            Entities.Concrete.Ogrenci ogrenci = new Entities.Concrete.Ogrenci();  //yeni nesne
            ogrenci.Ad = txtAd.Text;  //text'e adı yazdırabilmek için
            ogrenci.Soyad = txtSoyad.Text; //text'e soyadı yazdırabilmek için
            ogrenci.Tel = txtTel.Text; //text'e teli yazdırabilmek için
            ogrenci.Eposta = txtEposta.Text; //text'e epostayı yazdırabilmek için
            ogrenci.Adres = txtAdres.Text; //text'e adresi yazdırabilmek için
            ogrenci.Sifre = txtSifre.Text; //text'e şifreyi yazdırabilmek için
            ogrenci.Tc = txtTc.Text; //text'e tc'yi yazdırabilmek için
            ogrenci.Borc = Convert.ToInt32(txtBorc.Text); //text'e borcu yazdırabilmek için
            ogrenci.Id = Convert.ToInt32(txtId.Text); //text'e Id'yi yazdırabilmek için
            ogrenciService.guncelle(ogrenci); //güncelliyoruz.
            DataGridViewFill();   //dataGrid'i burda çağırıyoruz, görebilmek için
            MessageBox.Show("Başarıyla Guncellendi"); //güncellendğine dair messageBox'a mesaj atıyoruz.

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e) //Seçili olan satırı alttakı textBoxlara atamak için
        {
            txtId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtTel.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtEposta.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtAdres.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtSifre.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtTc.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtBorc.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
        }


        private void btnKtpEkle_Click(object sender, EventArgs e)
        {
            Kitap kitap = new Kitap();  //yeni nesne
            kitap.Adi = txtAdi.Text;  //text'e adı yazdırabilmek için
            kitap.Yazari = txtYazari.Text;  //text'e yazarı yazdırabilmek için
            kitap.SayfaSayisi = txtSayfaSayisi.Text;  //text'e sayfa sayısını yazdırabilmek için
            kitap.BasimTarihi = Convert.ToDateTime(txtBasimTarihi.Text);  //text'e basım tarihini yazdırabilmek için
            kitap.Turu = txtTuru.Text;  //text'e türünü yazdırabilmek için
            kitapService.ekle(kitap);  //ekliyoruz
            MessageBox.Show("Başarıyla Eklendi.");  //eklendiğine dair messageBox'a değer atıyoruz.
            DataGridViewFill();  //dataGrid'i burda çağırıyoruz, görebilmek için
        }

        private void btnKtpSil_Click(object sender, EventArgs e)
        {
            Kitap kitap = new Kitap();  //yeni nesne
            int id = Convert.ToInt32(txtId.Text);  //İd'sine bağlı silmek için
            kitapService.sil(id);  //siliyoruz.
            MessageBox.Show("Silindi"); //silindiğine dair messageBox'a değer atıyoruz.
            DataGridViewFill();  //dataGrid'i burda çağırıyoruz, görebilmek için
        }

        private void btnKtiGuncelle_Click(object sender, EventArgs e)
        {
            Kitap kitap = new Kitap(); //yeni nesne
            kitap.Adi = txtAdi.Text;  //text'e adı yazdırmak için
            kitap.Yazari = txtYazari.Text;  //text'e yazarı yazdırmak için
            kitap.SayfaSayisi = txtSayfaSayisi.Text;  //text'e sayfa sayısını yazdırmak için
            kitap.BasimTarihi = Convert.ToDateTime(txtBasimTarihi.Text);  //text'e basım tarihini yazdırmak için
            kitap.Turu = txtTuru.Text;  //text'e türünü yazdırmak için
            kitap.Id = Convert.ToInt32(txtId.Text);  //text'e Id'sini yazdırmak için
            kitapService.guncelle(kitap);  //güncelliyoruz
            MessageBox.Show("Başarıyla Güncellendi"); //güncellendiğine dair messageBox'a değer atıyoruz.
            DataGridViewFill(); //dataGrid'i burda çağırıyoruz, görebilmek için
        }

        private void dgvKitap_SelectionChanged(object sender, EventArgs e)  //seçili satırı text'lere atamak için
        {
            textBox1.Text = dgvKitap.CurrentRow.Cells[0].Value.ToString();
            txtAdi.Text = dgvKitap.CurrentRow.Cells[1].Value.ToString();
            txtYazari.Text = dgvKitap.CurrentRow.Cells[2].Value.ToString();
            txtSayfaSayisi.Text = dgvKitap.CurrentRow.Cells[3].Value.ToString();
            txtBasimTarihi.Text = dgvKitap.CurrentRow.Cells[4].Value.ToString();
            txtTuru.Text = dgvKitap.CurrentRow.Cells[5].Value.ToString();
        }


        private void btnEmanetEkle_Click(object sender, EventArgs e)
        {
            Emanet emanet = new Emanet();  //yeni nesne
            emanet.Ogrenci_Id = Convert.ToInt32(txtogrid.Text);  //text'e ogrenci id'sini yazdırmak için
            emanet.Kitap_Id = Convert.ToInt32(txtkid.Text);  //text'e kitap Is'sini yazdırmak için
            emanet.Kitap_emanet_verilme = DateTime.Now.Date;  //text'e kitabın emanet verilme tarihini yazdırmak için
            emanet.Kitap_teslim_edilme = dtpemanetedilme.Value.Date;  //text'e kitabı geri alınması gereken tarihi yazdırmak için
            emanet.Kitap_teslim_edilen = null; //text'e teslim ettiği ya da teslim etmemişse olan tarihi yazdırmak için 
            if (string.IsNullOrEmpty(txtBorc.Text))  
            {
                txtBorc.Text = "0";
            }
            emanet.Kitap_borc = Convert.ToInt32(txtBorc.Text);  //borcu yazdırabilmek için
            emanetService.ekle(emanet); //ekliyoruz
            MessageBox.Show("Başarıyla Eklendi."); //eklendiğine dair messageBox'a değer atıyoruz.
            DataGridViewFill();  //dataGrid'i burda çağırıyoruz, görebilmek için
            tablorenk();  //tabloya renk vermek için tablorenk metodumuz.

        }

        private void btnGeriAl_Click(object sender, EventArgs e)
        {
            Emanet emanet = new Emanet();  //yeni nesne
            emanet.Ogrenci_Id = Convert.ToInt32(txtogrid2.Text);  //text'e Ogrenci Id'sini yazdırmak için
            emanet.Kitap_Id = Convert.ToInt32(txtkid2.Text); //text'e Kitap Id'sini yazdırmak için
            emanet.Kitap_emanet_verilme = Convert.ToDateTime(txtemanetverilme2.Text); //text'e kitabın emanet verilme tarihini yazdırmak için
            emanet.Kitap_teslim_edilme = Convert.ToDateTime(txtemanetedilme2.Text); //text'e geri alınması gereken tarihi yazdırmak için
            emanet.Kitap_teslim_edilen = DateTime.Now.Date; //text'e teslim etmesi gereken tarihi yazdırmak için
            emanet.Kitap_borc = Convert.ToInt32(txtkborc2.Text); //text'e borcunu yazdırmak için
            emanet.Id = Convert.ToInt32(txtemanetid.Text); //text'e Id'sini yazdırmak için
            emanetService.guncelle(emanet);  //gğncelliyoruz
            DataGridViewFill();  //dataGrid'i burda çağırıyoruz, görebilmek için
            tablorenk(); //tabloya renk vermek için tablorenk metodumuz.
            MessageBox.Show("Kitap teslim edildi."); //geri geldiğine dair messageBox'a değer atıyoruz.
        }


        private void tabPage1_Click(object sender, EventArgs e)
        {
        }
        private void tabPage2_Click(object sender, EventArgs e)
        {
        }
        private TabPage tabOgr;
        private TabPage tabKtp;

        private void btnGeriDon_Click(object sender, EventArgs e)
        {

            Baslangic bs = new Baslangic(); //başlanıgıca geri dönmek için yeni nesne
            bs.Show(); //göstermesi için
            this.Close();  //eskisini kapatması için
        }


        private void PersonelIslemler_Load(object sender, EventArgs e)
        {

        }
        void tablorenk()  //renk vermek için kullandığımız metodumuz
        {

            for (int i = 0; i < dGwEmanet.Rows.Count; i++)
            {
                var row = dGwEmanet.Rows[i];
                if (row.Cells[5].Value == null) //verim tarihi
                {
                    var totalDays = (DateTime.Now - (DateTime)row.Cells[4].Value).TotalDays; //suanki tarihe göre ayarlı eski tarihi çıkartıldığı yeni bi nesne
                    if (totalDays > 0) //yeni nesnemiz sıfırdan büyükse demek ki geç hala teslim edilmemiş o yuzden kırmızı yazması için koşul
                    {
                        dGwEmanet.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                        dGwEmanet.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                        continue;
                    }
                    else if (totalDays > -2 && totalDays < 0)  //eğer 2 gün kaldıysa yanması gereken sarı rengi için
                    {
                        dGwEmanet.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                        dGwEmanet.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                        continue;
                    }
                }
                else //teslim ettiyse yanması gereken yeşil rengi
                {
                    dGwEmanet.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                    dGwEmanet.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                }

            }

        }

        private void txtemanetid_TextChanged(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(txtemanetid.Text))
            {
                Emanet suankiEmanet = emanetler.FirstOrDefault(x => x.Id == Convert.ToInt32(txtemanetid.Text));
                if (suankiEmanet != null)
                {
                    txtkid2.Text = suankiEmanet.Kitap_Id.ToString();
                    txtogrid2.Text = suankiEmanet.Ogrenci_Id.ToString();
                    txtemanetverilme2.Text = suankiEmanet.Kitap_emanet_verilme.ToString();
                    txtemanetedilme2.Text = suankiEmanet.Kitap_teslim_edilme.ToString();
                    dtpteslim2.Text = suankiEmanet.Kitap_teslim_edilen.ToString();
                    txtkborc2.Text = suankiEmanet.Kitap_borc.ToString();
                }
            }
        }

        private void dGwEmanet_DataSourceChanged(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {


        }

        private void PersonelTabs_SelectedIndexChanged(object sender, EventArgs e) //tabPage kullandığım için renk metodumuz kullanırken sıkıntı 3.olan emanet tablosuna erişim için kullanıldı.
        {
            string currentTab = tabPage3.AccessibilityObject.Name;
            if (currentTab == "Emanet İşlemleri")
            {
                tablorenk();
            }
        }
    }
}


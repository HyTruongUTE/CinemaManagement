using DBMS1.FFunction;
using DBMS1.FTable;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS1
{
    public partial class FMain : Form
    {
        AddClass addClass = new AddClass();

        
        public FMain()
        {
            InitializeComponent();
            addClass.Add_Form(new FHome(), pnShowTable);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public enum ButtonName
        {
            btnPhongChieu,
            btnLichChieu,
            btnFnB,
            btnVe,
            btnGheNgoi,
            btnBoPhim,
            btnKhachHang,
            btnHoaDon,
            btnKhoFnB,
            btnXemGheNgoi,
            btnThoat,
            btnMuaVeFnB,
            btnAccount,
            btnHome
        }
        Bunifu.UI.WinForms.BunifuButton.BunifuButton btnIsClicked = null;
        Bunifu.UI.WinForms.BunifuButton.BunifuButton lastBtnClicked = null;

        private void btn_Click(object sender, EventArgs e)
        {
            Bunifu.UI.WinForms.BunifuButton.BunifuButton btn = (Bunifu.UI.WinForms.BunifuButton.BunifuButton)sender;
            ButtonName buttonName;
            bool isParsed = Enum.TryParse(btn.Name, out buttonName);
            if (!isParsed)
            {
                return;
            }
            lastBtnClicked = btnIsClicked;
            btnIsClicked = btn;
            switch (buttonName)
            {
                case ButtonName.btnPhongChieu:
                    addClass.Add_Form(new FPhongChieu(), pnShowTable);
                    break;
                case ButtonName.btnLichChieu:
                    addClass.Add_Form(new FLichChieu(), pnShowTable);
                    break;
                case ButtonName.btnFnB:
                    addClass.Add_Form(new FFnB(), pnShowTable);
                    break;
                case ButtonName.btnVe:
                    addClass.Add_Form(new FVe(), pnShowTable);
                    break;
                case ButtonName.btnGheNgoi:
                    addClass.Add_Form(new FGheNgoi(), pnShowTable);
                    break;
                case ButtonName.btnBoPhim:
                    addClass.Add_Form(new FBoPhim(), pnShowTable);
                    break;
                case ButtonName.btnKhachHang:
                    addClass.Add_Form(new FKhachHang(), pnShowTable);
                    break;
                case ButtonName.btnHoaDon:
                    addClass.Add_Form(new FHoaDon(), pnShowTable);
                    break;
                case ButtonName.btnKhoFnB:
                    addClass.Add_Form(new FXemKhoFnB(), pnShowTable);
                    break;
                case ButtonName.btnXemGheNgoi:
                    addClass.Add_Form(new FXemGheNgoi(), pnShowTable);
                    break;
                case ButtonName.btnMuaVeFnB:
                    addClass.Add_Form(new FMuaVe(), pnShowTable);
                    break;
                case ButtonName.btnAccount:
                    addClass.Add_Form(new FAccount(), pnShowTable);
                    break;
                case ButtonName.btnHome:
                    addClass.Add_Form(new FHome(), pnShowTable);
                    break;
                case ButtonName.btnThoat:
                    Application.Exit();
                    break;
                default:
                    break;
            }
        }
    }
}

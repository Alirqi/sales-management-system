using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;

namespace SalesSystem.CLASSES.Initialization
{

    public class SystemInformation
    {
        CLASSES.DAL.DbInterfaceMediator.DatabaseManager con = new CLASSES.DAL.DbInterfaceMediator.DatabaseManager();
        DataTable dt = new DataTable();

        public SystemInformation()
        {
            dt = con.GetData("SELECT_SYSTEM_INFORMATION");
            Name = dt.Rows[0][1].ToString();            
            byte[] imageBytes = (byte[])dt.Rows[0][2];
            _imageBytes = imageBytes;
            Address = dt.Rows[0][3].ToString();
            phoneNumber = dt.Rows[0][4].ToString();
        }


        public static byte[] _imageBytes;
        private string _imagePath;

        [Category("Chose Image"), Description("Image of the object")]
        [Browsable(false)]
        public byte[] ImageBytes
        {
            get { return _imageBytes; }
            set
            {
                _imageBytes = value;
                OnPropertyChanged("ImageBytes");
            }
        }

        public static string Name;

        [Category("Setting")]
        [Description("The setting of the System.")]       
        [DefaultValue("Default Value")]
        public string SystemName
        {
            get { return Name; }
            set { Name = value; }
        }

        public static string phoneNumber  ;

        [Category("Setting")]
        [Description("Enter The System Phone Number")]
        [DefaultValue("Default Value")]
        public string SystemPhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public static string Address ;

    

        [Category("Setting")]
        [Description("Enter The System Your address")]
        [DefaultValue("Default Value")]
        public string SystemAddresses
        {
            get { return Address; }
            set { Address = value; }
        }

        //[Category("Size"), Description("Image Size")]
        //public int Width { get; set; }
        //[Category("Size"), Description("Image Size")]
        //public int Height { get; set; }
        //[Category("Size"), Description("Image Size")]
        //public RotateFlipType RotateFlip { get; set; }

        [Category("Chose Image"), Description("Image of the object")]
        [Editor(typeof(OpenFileDialogEditor), typeof(UITypeEditor))]
        public Image Image
        {
            get
            {
                if (_imageBytes != null)
                {
                    using (MemoryStream ms = new MemoryStream(_imageBytes))
                    {
                        return Image.FromStream(ms);
                    }                   
                }
                return null;
            }
            set
            {
                if (value != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        value.Save(ms, value.RawFormat);
                        _imageBytes = ms.ToArray();
                    }
                }
                else
                {
                    _imageBytes = null;
                }
                OnPropertyChanged("Image");
            }
        }

        [Browsable(false)]
        public string ImagePath
        {
            get { return _imagePath; }
            set
            {
                _imagePath = value;
                OnPropertyChanged("ImagePath");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class OpenFileDialogEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SystemInformation systemInformation = context.Instance as SystemInformation;
                systemInformation.ImagePath = dialog.FileName;
                return Image.FromFile(dialog.FileName);
            }

            return value;


            //OpenFileDialog dialog = new OpenFileDialog();
            //dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

            //if (dialog.ShowDialog() == DialogResult.OK)
            //{
            //    ImageSelector imageSelector = context.Instance as ImageSelector;
            //    imageSelector.ImagePath = dialog.FileName;

            //    // تحميل الصورة
            //    Image image = Image.FromFile(dialog.FileName);

            //    // تطبيق الخصائص المحددة
            //    if (imageSelector.Width > 0 && imageSelector.Height > 0)
            //    {
            //        image = ResizeImage(image, imageSelector.Width, imageSelector.Height);
            //    }
            //    if (imageSelector.RotateFlip != RotateFlipType.RotateNoneFlipNone)
            //    {
            //        image.RotateFlip(imageSelector.RotateFlip);
            //    }

            //    // تحويل الصورة إلى مصفوفة بايتات
            //    using (MemoryStream ms = new MemoryStream())
            //    {
            //        image.Save(ms, image.RawFormat);
            //        imageSelector.ImageBytes = ms.ToArray();
            //    }

            //    return image;
            //}

            //return value;
        }
        //private Image ResizeImage(Image image, int width, int height)
        //{
        //    Bitmap resizedImage = new Bitmap(width, height);
        //    using (Graphics graphics = Graphics.FromImage(resizedImage))
        //    {
        //        graphics.DrawImage(image, 0, 0, width, height);
        //    }
        //    return resizedImage;
        //}

    }
   

}

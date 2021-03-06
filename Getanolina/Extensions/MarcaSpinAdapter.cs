using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Getanolina.Library.Model;

namespace Getanolina.Extensions
{
    public class MarcaSpinAdapter : ArrayAdapter<Modelo>
    {
        private Context context;
        private IList<Modelo> objects;

        public MarcaSpinAdapter(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer)
        {
        }

        public MarcaSpinAdapter(Context context, int textViewResourceId) : base(context, textViewResourceId)
        {
        }

        public MarcaSpinAdapter(Context context, int resource, int textViewResourceId)
            : base(context, resource, textViewResourceId)
        {
        }

        public MarcaSpinAdapter(Context context, int textViewResourceId, Modelo[] objects)
            : base(context, textViewResourceId, objects)
        {
        }

        public MarcaSpinAdapter(Context context, int resource, int textViewResourceId, Modelo[] objects)
            : base(context, resource, textViewResourceId, objects)
        {
        }

        public MarcaSpinAdapter(Context context, int textViewResourceId, IList<Modelo> objects)
            : base(context, textViewResourceId, objects)
        {
            this.context = context;
            this.objects = objects;

        }

        public MarcaSpinAdapter(Context context, int resource, int textViewResourceId, IList<Modelo> objects)
            : base(context, resource, textViewResourceId, objects)
        {
        }

        public new int Count()
        {
            return objects.Count;
        }

        public Modelo GetModelo(int position)
        {
            return objects[position];
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            try
            {
                var label = new TextView(context) { Text = objects[position].GetName() };
                System.Diagnostics.Debug.WriteLine("Bota na cabe�a que estilo n�o � marra: " + label.Text);
                return label;

            }
            catch (Exception)
            {
                System.Diagnostics.Debug.WriteLine("ok: " + objects.Count);

            }
            return null;
        }

        public override View GetDropDownView(int position, View convertView, ViewGroup parent)
        {
            var label = new TextView(context) { Text = objects[position].GetName() };
            return label;
        }
    }
}
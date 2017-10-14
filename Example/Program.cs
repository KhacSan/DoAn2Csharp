using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;


namespace Example
{
    class Program
    {
        [DllImport("C:\\Users\\San\\Desktop\\plplot-5.13.0\\Build_New\\dll\\Debug\\plplot.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void c_pladv(int x);

        [DllImport("C:\\Users\\San\\Desktop\\plplot-5.13.0\\Build_New\\dll\\Debug\\plplot.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void c_plinit();

        [DllImport("C:\\Users\\San\\Desktop\\plplot-5.13.0\\Build_New\\dll\\Debug\\plplot.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void c_plcol0(int icol0);

        [DllImport("C:\\Users\\San\\Desktop\\plplot-5.13.0\\Build_New\\dll\\Debug\\plplot.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void c_plenv(double xmin, double xmax, double ymin, double ymax, int just, int axis);

        [DllImport("C:\\Users\\San\\Desktop\\plplot-5.13.0\\Build_New\\dll\\Debug\\plplot.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void c_plline(int n, double[] x, double[] y);

        [DllImport("C:\\Users\\San\\Desktop\\plplot-5.13.0\\Build_New\\dll\\Debug\\plplot.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void c_pllab(string xlabel, string ylabel, string tlabel);

        [DllImport("C:\\Users\\San\\Desktop\\plplot-5.13.0\\Build_New\\dll\\Debug\\plplot.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void c_plend();

        [DllImport("C:\\Users\\San\\Desktop\\plplot-5.13.0\\Build_New\\dll\\Debug\\plplot.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void c_plsdev(string devname);

        [DllImport("C:\\Users\\San\\Desktop\\plplot-5.13.0\\Build_New\\dll\\Debug\\plplot.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void c_plscmap1n(int ncol1);

        [DllImport("C:\\Users\\San\\Desktop\\plplot-5.13.0\\Build_New\\dll\\Debug\\plplot.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void c_plscmap1l(int itype, int npts, double[] intensity, double[] coord1, double[] coord2, double[] coord3, bool[] alt_hue_path);

        [DllImport("C:\\Users\\San\\Desktop\\plplot-5.13.0\\Build_New\\dll\\Debug\\plplot.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void c_plw3d(double basex, double basey, double height, double xmin,
         double xmax, double ymin, double ymax, double zmin,
         double zmax, double alt, double az);

        [DllImport("C:\\Users\\San\\Desktop\\plplot-5.13.0\\Build_New\\dll\\Debug\\plplot.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void c_plbox3(string xopt, string xlabel, double xtick, int nxsub,
          string yopt, string ylabel, double ytick, int nysub,
          string zopt, string zlabel, double ztick, int nzsub);

        [DllImport("C:\\Users\\San\\Desktop\\plplot-5.13.0\\Build_New\\dll\\Debug\\plplot.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void c_plmeshc(double[] x, double[] y, double[,] z, int nx, int ny, int opt,
           double[] clevel, int nlevel);

        [DllImport("C:\\Users\\San\\Desktop\\plplot-5.13.0\\Build_New\\dll\\Debug\\plplot.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void c_plmtex(string side, double disp, double pos, double just, string text);

        //[DllImport("C:\\Users\\San\\Desktop\\plplot-5.13.0\\Build_New\\dll\\Debug\\plplot.dll", CallingConvention = CallingConvention.Cdecl)]
        //public static extern unsafe void plMinMax2dGrid(double[,] f, int nx, int ny, double* fmax, double* fmin);


        public static void plMinMax2dGrid(double[,] f, int nx, int ny, ref double fmax, ref double fmin)
        {
            fmax = f[0, 0];
            fmin = f[0, 0];
            for (int i = 0; i < nx; i++)
            {
                for (int j = 0; j < ny; j++)
                {
                    if (f[i, j] > fmax) fmax = f[i, j];
                    if (f[i, j] < fmin) fmin = f[i, j];
                }
            }
        }



        //[DllImport("C:\\Users\\San\\Desktop\\plplot-5.13.0\\Build_New\\dll\\Debug\\plplot.dll", CallingConvention = CallingConvention.Cdecl)]
        //public static extern void plAlloc2dGrid(double[,] f, int nx, int ny);

        static void Main(string[] args)
        {
            const int BASE_CONT = 0x008;
            const int MAG_COLOR = 0x004;
            const int DRAW_LINEXY = 0x003;
            const int LEVELS = 10;
            const int XPTS = 35;            // Data points in x
            const int YPTS = 46;
            int i, j, k;
            double[] x = new double[XPTS];
            double[] y = new double[YPTS];
            double[,] z = new double[XPTS, YPTS];
            double xx, yy;
            int nlevel = LEVELS;
            double[] clevel = new double[LEVELS];
            double zmin = 0, zmax = 0, step;

            // (void)plparseopts(&argc, argv, PL_PARSE_FULL);

            // Initialize plplot
            c_plsdev("svg");
            //plssub(2, 4);
            c_plinit();


            //plAlloc2dGrid(z, XPTS, YPTS);
            for (i = 0; i < XPTS; i++)
            {
                x[i] = 3.0 * (double)(i - (XPTS / 2)) / (double)(XPTS / 2);
            }

            for (i = 0; i < YPTS; i++)
                y[i] = 3.0 * (double)(i - (YPTS / 2)) / (double)(YPTS / 2);

            for (i = 0; i < XPTS; i++)
            {
                xx = x[i];
                for (j = 0; j < YPTS; j++)
                {
                    yy = y[j];
                    z[i, j] = 3.0 * (1.0 - xx) * (1.0 - xx) * Math.Exp(-(xx * xx) - (yy + 1.0) * (yy + 1.0)) -
                              10.0 * (xx / 5.0 - Math.Pow(xx, 3.0) - Math.Pow(yy, 5.0)) * Math.Exp(-xx * xx - yy * yy) -
                              1.0 / 3.0 * Math.Exp(-(xx + 1) * (xx + 1) - (yy * yy));
                }
            }
            plMinMax2dGrid(z, XPTS, YPTS, ref zmax, ref zmin);
            cmap1_init();
            c_plcol0(1);
            c_plenv(-1.0, 1.0, -1.0, 1.5, 0, 1);
            //plvpor(0.0, 1.0, 0.0, 0.9); // Specify viewport using normalized subpage coordinates (left,right,buttom,top)
            //plwind(-1.0, 1.0, -1.0, 1.5);  //Specify window
            c_plw3d(1.0, 1.0, 1.2, -3.0, 3.0, -3.0, 3.0, zmin, zmax, 17.0, 115.0); // Configure the transformations required for projecting a 3D surface on a 2D window
            c_plbox3("bnstu", "x axis", 0.0, 0,
               "bnstu", "y axis", 0.0, 0,
               "bcdmnstuv", "z axis", 0.0, 4);
            c_plcol0(2);

            c_plmeshc(x, y, z, XPTS, YPTS, DRAW_LINEXY | MAG_COLOR | BASE_CONT, clevel, nlevel);

            c_plcol0(3);
            c_plmtex("t", 1.0, 0.5, 0.5, "#frPLplot Example 11 - Alt=17, Az=115, Opt=3");
            c_plend();
            Console.ReadKey();
        }

        static void cmap1_init()
        {
            double[] i = new double[2]; double[] h = new double[2];
            double[] l = new double[2]; double[] s = new double[2];

            i[0] = 0.0;         // left boundary 
            i[1] = 1.0;         // right boundary

            h[0] = 240;         // blue -> green -> yellow ->
            h[1] = 0;           // -> red

            l[0] = 0.6;//anh sang
            l[1] = 0.6;

            s[0] = 0.8;
            s[1] = 0.8; //dam nhat

            c_plscmap1n(256); //Set number of colors in cmap1
            c_plscmap1l(0, 2, i, h, l, s, null);  //Set cmap1 colors using a piece-wise linear relationship
        }
    }
}

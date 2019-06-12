using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HalconDotNet;
namespace Vision
{
    public static class Calibration
    {
        // 摘要:
        //     用于不需要相机参数的多点标定，最好为九点
        //
        // 参数:
        //   point_x：世界坐标系点横坐标数组
        //   point_y: 世界坐标系点纵坐标数组
        //   pixel_x: 相机坐标系点row数组
        //   pixel_y：相机坐标系点column数组
        //
        // 返回结果:
        //     
        public static HTuple Calib9(double[] point_x,double []point_y,double[] pixel_x,double[] pixel_y)
        {
            HTuple x = new HTuple(point_x);           
            HTuple y = new HTuple(point_y);
            HTuple pix_x=new HTuple(pixel_x);
            HTuple pix_y=new HTuple(pixel_y);
            HTuple hom2d=null;
            HOperatorSet.VectorToHomMat2d(pixel_x, pixel_y, x, y, out hom2d);
            return hom2d;
        }
        public static void SaveHom2d(HTuple hom2d,string FilePath)
        {
            HOperatorSet.WriteTuple(hom2d, FilePath);
        }
    }
}

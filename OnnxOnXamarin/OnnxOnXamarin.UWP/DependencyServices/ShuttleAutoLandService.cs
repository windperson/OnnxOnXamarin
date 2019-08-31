using OnnxOnXamarin.DependencyServices;
using System;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(OnnxOnXamarin.UWP.DependencyServices.ShuttleAutoLandService))]
namespace OnnxOnXamarin.UWP.DependencyServices
{
    public class ShuttleAutoLandService : IShuttleAutoLand
    {
        public async Task<bool> CanUseAutoLanding(int inputSTABILITY, int inputERROR, int inputSIGN, int inputWIND, int inputMAGNITUDE, int inputVISIBILITY)
        {
            var modelFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/export_model.onnx"));
            var model = await export_modelModel.CreateFromStreamAsync(modelFile);

            var inputData = new export_modelInput
            {
                int64_input = Windows.AI.MachineLearning.TensorInt64Bit.CreateFromIterable(
                    new long[] { 1, 6 },
                    new long[] { inputSTABILITY, inputERROR, inputSIGN, inputWIND, inputMAGNITUDE, inputVISIBILITY })
            };

            var prediction = await model.EvaluateAsync(inputData);

            var isAutoLand = prediction.output_label.GetAsVectorView().First();

            return isAutoLand == 2;
        }
    }
}

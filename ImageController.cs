using FruitHealth.Areas.Identity.Data;
using FruitHealth.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace FruitHealth.Controllers
{
    public class ImageController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private object yourData;
        private object _context;

        public ImageController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult UploadImage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ImageUpload(string submitButton, IFormFile imageFile)
        {
            if (submitButton == "save")
            {
                //Console.WriteLine(ViewBag.PredictionResult);
                //tring? dataToSave = ViewBag.PredictionResult.PredictedLabel as string;
                //if (TempData["predictionResult"])
                //{
                Console.WriteLine("This is a string: {0}", TempData["predictionResult"]);
                Console.WriteLine("This is a string: {0}", TempData["ImagePath"]);
                Console.WriteLine("This is a string: {0}", TempData["Score"]);
                //}

                var model = new FruitHealthPredictionResult
                {
                    // Assuming YourModel has properties that match the data you want to save
                    PredictedLabel = Convert.ToString(TempData["predictionResult"]),
                    Score = Convert.ToString(TempData["Score"]),
                    ImageFilePath = Convert.ToString(TempData["ImagePath"]),
                    PredictedDateTime = DateTime.Now,
                    // Add more properties as needed
                };
                fruitHealthContext fruitContext = new fruitHealthContext();
                // Add the model to the database context
                fruitContext.FruitHealthPredictionResults.Add(model);

                // Save changes to the database
                fruitContext.SaveChanges();


            }
            else
            {
                var file = Request.Form.Files[0];

                if (file != null && file.Length > 0)
                {
                    var imagesFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                    var filePath1 = Path.Combine(imagesFolder, file.FileName);
                    var filePath = Path.Combine("/images/", file.FileName);

                    using (var stream = new FileStream(filePath1, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    ViewBag.ImagePath = filePath;
                    var imageBytes = System.IO.File.ReadAllBytes(filePath1);
                    FruitHealthModel1.ModelInput sampleData = new FruitHealthModel1.ModelInput()
                    {
                        ImageSource = imageBytes
                    };

                    //Load model and predict output
                    var result = FruitHealthModel1.Predict(sampleData);
                    ViewBag.PredictionResult = result.PredictedLabel;
                    switch (result.PredictedLabel)
                    {
                        case "diseasedwatermelon":
                            ViewBag.Score = (result.Score[0] * 100).ToString("F2");
                            break;
                        case "diseasedapple":
                            ViewBag.Score = (result.Score[1] * 100).ToString("F2");
                            break;
                        case "healthymango":
                            ViewBag.Score = (result.Score[2] * 100).ToString("F2");
                            break;
                        case "healthyapple":
                            ViewBag.Score = (result.Score[3] * 100).ToString("F2");
                            break;
                        case "healthywatermelon":
                            ViewBag.Score = (result.Score[4] * 100).ToString("F2");
                            break;
                        case "diseasedmango":
                            ViewBag.Score = (result.Score[5] * 100).ToString("F2");
                            break;
                        default:
                            ViewBag.Score = 0;
                            break;

                    }

                    TempData["predictionResult"] = result.PredictedLabel;
                    TempData["ImagePath"] = filePath1;
                    TempData["Score"] = ViewBag.Score;

                    Console.WriteLine(result);
                }
            }

            return View("UploadImage"); // Redirect to home page after successful upload
        }

    }
}


using Microsoft.AspNetCore.Mvc;

namespace simpleApi.Controllers;

//[Route("api/[controller]")]
[Route("")]
[ApiController]
public class SimpleController: ControllerBase
{

    //Get:api/Simple
    [HttpGet]
    public ActionResult Get(){
        // return Ok("Hello World!! - simple controller");
        var htmlContent = GenerateLandingPage();
        // var htmlContent = @"
        //     <html>
        //     <head>
        //         <title>Cats & Dogs API</title>
        //         <style>
        //             body {
        //                 display: flex;
        //                 flex-direction: column;
        //                 justify-content: center;
        //                 align-items: center;
        //                 height: 100vh;
        //                 margin: 0;
        //                 font-family: Arial, sans-serif;
        //                 background-color: #f0f8ff;
        //             }
        //             h1 {
        //                 margin-bottom: 20px;
        //             }
        //             a {
        //                 text-decoration: none;
        //                 color: #007BFF;
        //             }
        //             a:hover {
        //                 text-decoration: underline;
        //             }
        //             img {
        //                 max-width: 100%;
        //                 height: auto;
        //                 margin-top: 20px;
        //             }
        //         </style>
        //     </head>
        //     <body>
        //         <h1>Cats & Dogs API</h1>
        //         <p><a href='/swagger'>Swagger</a>.</p>
        //         <p><a href='/api/Dogs'>Dogs API</a>.</p>

        //     </body>
        //     </html>
        //     ";
        return Content(htmlContent, "text/html");
    }


    private string GenerateLandingPage()
    {
        return @"
            <html>
            <head>
                <title>Cats & Dogs API</title>
                <style>
                    body {
                        display: flex;
                        flex-direction: column;
                        justify-content: center;
                        align-items: center;
                        height: 100vh;
                        margin: 0;
                        font-family: Arial, sans-serif;
                        background-color: #d3d3d3; /* light grey */
                    }
                    h1 {
                        margin-bottom: 20px;
                    }
                    a {
                        text-decoration: none;
                        color: #007BFF;
                    }
                    a:hover {
                        text-decoration: underline;
                    }
                    img {
                        max-width: 100%;
                        height: auto;
                        margin-top: 20px;
                    }
                </style>
            </head>
            <body>
                <h1>Cats & Dogs API</h1>
                <p><a href='/swagger'>Swagger</a>.</p>
                <p><a href='/api/Dogs'>Dogs API</a>.</p>
            </body>
            </html>
        ";
    }
}

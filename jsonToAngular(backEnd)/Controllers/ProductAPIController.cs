using jsonToAngular_backEnd_.Repository_Pattern;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace jsonToAngular_backEnd_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {

        private SendForm sendForm;


        public ProductAPIController(IConfiguration  configuration)
        {
            sendForm=new SendForm(configuration);
                
        }

        [HttpGet]
        [Route("SendFormModule")]
        public string SendFormAngularApp()
        {
            var FormJsonFormat = JsonConvert.SerializeObject(sendForm.FormRepository());

            return FormJsonFormat;
        }
        [HttpPost]
        [Route("GetFormModule")]
        public void GetFromAngularApp([FromBody] Object json)
        {
            sendForm.storeInformation(json);          
        }

        [HttpGet]
        [Route("SendFinalForm")]
        public string SendFinalForm()
        {
            var FinalForm = JsonConvert.SerializeObject(sendForm.FetchFinalData());

            return FinalForm;
        }


    }
  
}

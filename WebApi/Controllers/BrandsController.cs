using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Feature.Brands.Commands.Create;
using Application.Feature.Brands.Commands.Delete;
using Application.Feature.Brands.Commands.Update;
using Application.Feature.Brands.Queries.GetById;
using Application.Feature.Brands.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBrandCommand createBrandCommand)
        {
            CreatedBrandResponse response =  await Mediator.Send(createBrandCommand);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListBrandQuery getListBrandQuery = new() { PageRequest = pageRequest };
            GetListResponse<GetListBrandListItemDto> response = await Mediator.Send(getListBrandQuery);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            GetByIdBrandQuery getByIdBrandQuery = new() { Id = id };
            GetByIdBrandResponse response = await Mediator.Send(getByIdBrandQuery);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBrandCommand updateBrandCommand)
        {
            UpdateBrandResponse response = await Mediator.Send(updateBrandCommand);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteBrandCommand deleteBrandCommand)
        {
            DeleteBrandResponse response = await Mediator.Send(deleteBrandCommand);

            return Ok(response);
        }
    }
}


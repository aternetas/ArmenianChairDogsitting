﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ArmenianChairDogsitting.API.Models;
using ArmenianChairDogsitting.API.Roles;
using ArmenianChairDogsitting.API.Extensions;

namespace ArmenianChairDogsitting.API.Controllers
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class СommentsController : Controller
    {
        [HttpPost]
        [AuthorizeByRole(Role.Client)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void), StatusCodes.Status422UnprocessableEntity)]
        public ActionResult<int> AddComment([FromBody] CommentRequest comment)
        {
            int id = 0;
            return Created($"{this.GetUri()}/{id}", id);
        }

        [HttpGet]
        [AuthorizeByRole(Role.Sitter, Role.Client)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(List<CommentResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public ActionResult<List<CommentResponse>> GetAllComments()
        {
            return Ok(new List<CommentResponse>());
        }

        [HttpDelete("{id}")]
        [AuthorizeByRole(Role.Client)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(CommentResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public ActionResult DelleteCommentById(int id)
        {
            return Ok(new CommentResponse());
        }

    }
}

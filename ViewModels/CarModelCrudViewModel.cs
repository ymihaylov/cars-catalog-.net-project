﻿using System;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using CarsCatalog.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarsCatalog.ViewModels
{
    public class CarModelCrudViewModel
    {
        public CarModelCrudViewModel()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public IFormFile Photo { get; set; }

        public string PhotoPath { get; set; }

        public string Description { get; set; }

        public int SelectedCarMakeId { get; set; }

        public SelectList CarMakeId { get; set; }

        public List<Comment> CommentsWaitingApproval { get; set; }

        public PhotosViewModel PhotosViewModel { get; set; }

        public List<IFormFile> Photos { get; set; }

        public List<Photo> PhotosEntities { get; set; }
    }
}

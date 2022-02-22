﻿using Microsoft.EntityFrameworkCore;
using UniClub.Domain.Entities;
using UniClub.Dtos.GetWithPagination;
using UniClub.Helpers;
using UniClub.Specifications;

namespace UniClub.Queries.GetWithPagination.Specifications
{
    public class GetStudentsWithPaginationSpecification : BaseSpecification<Person>
    {
        public GetStudentsWithPaginationSpecification(GetStudentsWithPaginationDto query)
        {
            SetFilterCondition(e => e.IsDeleted == false);

            if (!string.IsNullOrWhiteSpace(query.SearchValue))
            {
                SetFilterCondition((e => e.Id.ToString().Equals(query.SearchValue)
                                        || EF.Functions.Collate(e.Name, "SQL_Latin1_General_CP1_CI_AI").Contains(query.SearchValue)
                                        || e.Email.Contains(query.SearchValue)
                                        || e.DateOfBirth.ToString().Equals(query.SearchValue)
                                        || e.PhoneNumber.Contains(query.SearchValue)
                                        || EF.Functions.Collate(e.Address, "SQL_Latin1_General_CP1_CI_AI").Contains(query.SearchValue)));
            }
            if ((query.OrderBy != null))
            {
                if (new Person().HasProperty(query.OrderBy.ToString()))
                {
                    ApplyOrderBy(query.OrderBy.ToString());
                    ApplyOrder(query.IsAscending);
                }
                else
                {
                    query.OrderBy = null;
                }
            }

            ApplyPagination(query.PageNumber, query.PageSize);
        }
    }
}

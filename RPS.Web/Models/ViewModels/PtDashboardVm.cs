﻿using RPS.Core.Models;
using RPS.Core.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPS.Web.Models.ViewModels
{
    public class PtDashboardVm
    {
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }

        public int IssueCountOpen { get; set; }
        public int IssueCountClosed { get; set; }

        public int IssueCountActive { get { return IssueCountOpen + IssueCountClosed; } }
        public decimal IssueCloseRate { get { return Math.Round((decimal)IssueCountClosed / (decimal)IssueCountActive * 100m, 2); } }

        public int? SelectedAssigneeId { get; set; }
        public List<PtUser> Assignees { get; set; }

        public PtDashboardVm(PtDashboardStatusCounts statusCounts, List<PtUser> users, int? userId )
        {
            IssueCountOpen = statusCounts.OpenItemsCount;
            IssueCountClosed = statusCounts.ClosedItemsCount;
            Assignees = users;
            if (userId.HasValue)
                SelectedAssigneeId = userId.Value;
        }
    }
}
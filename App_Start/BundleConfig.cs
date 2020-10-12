﻿using System.Web;
using System.Web.Optimization;



namespace InterestRatesAPI
{
    public class BundleConfig
    {


        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));
        }
    }

}
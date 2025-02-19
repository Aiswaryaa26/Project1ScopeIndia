// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    // Countries
    var country_arr = ["Select Country", "AUSTRALIA", "INDIA", "NEW ZEALAND", "USA", "UAE", "MAURITIUS"];

    $.each(country_arr, function (i, item) {
        $('#RegCountry').append($('<option>', {
            value: item, // Use country name as the value
            text: item,
        }));
    });

    // States
    var s_a = {
        "Select RegCountry": "Select State",
        "AUSTRALIA": "Select State|QUEENSLAND|VICTORIA",
        "INDIA": "Select State|ANDHRAPRADESH|KARNATAKA|TAMILNADU|DELHI|GOA|W-BENGAL|GUJARAT|MADHYAPRADESH|MAHARASHTRA|RAJASTHAN|KERALA",
        "NEW ZEALAND": "Select RegState|AUCKLAND",
        "USA": "Select State|NEWJERSEY|ILLINOIS",
        "UAE": "Select State|DUBAI",
        "MAURITIUS": "Select State|MAURITIUS"
    };

    // Cities
    var c_a = {
        "Select RegState": "Select City",
        "QUEENSLAND": "BRISBANE",
        "VICTORIA": "MELBOURNE",
        "ANDHRAPRADESH": "HYDERABAD",
        "KARNATAKA": "BANGLORE",
        "TAMILNADU": "CHENNAI",
        "DELHI": "DELHI",
        "GOA": "GOA",
        "W-BENGAL": "KOLKATA",
        "GUJARAT": "AHMEDABAD1|AHMEDABAD2|AHMEDABAD3|BARODA|BHAVNAGAR|MEHSANA|RAJKOT|SURAT|UNA",
        "MADHYAPRADESH": "INDORE",
        "MAHARASHTRA": "MUMBAI|PUNE",
        "RAJASTHAN": "ABU",
        "AUCKLAND": "AUCKLAND",
        "NEWJERSEY": "EDISON",
        "ILLINOIS": "CHICAGO",
        "DUBAI": "DUBAI",
        "MAURITIUS": "MAURITIUS",
        "KERALA": "TRIVANDRUM|MALAPPURAM|WAYANAD|KANNUR|KOZHIKKODE|PATHANAMTHITTA|KOTTAYAM|IDUKKI|KASARGOD|ALAPPUZHA|PALAKKAD|THRISSUR|ERNAMKULAM|KOLLAM"
    };

    $('#RegCountry').change(function () {
        var c = $(this).val(); // Get the selected country name
        var state_arr = s_a[c] ? s_a[c].split("|") : ["Select State"];
        $('#RegState').empty();
        $('#RegCity').empty();

        // Populate the states dropdown
        $.each(state_arr, function (i, item_state) {
            $('#RegState').append($('<option>', {
                value: item_state,
                text: item_state,
            }));
        });

        // Reset the cities dropdown
        $('#RegCity').append($('<option>', {
            value: '0',
            text: 'Select City',
        }));
    });

    $('#RegState').change(function () {
        var s = $(this).val(); // Get the selected state name
        var city_arr = c_a[s] ? c_a[s].split("|") : ["Select City"];
        $('#RegCity').empty();

        // Populate the cities dropdown
        $.each(city_arr, function (i, item_city) {
            $('#RegCity').append($('<option>', {
                value: item_city,
                text: item_city,
            }));
        });
    });

});
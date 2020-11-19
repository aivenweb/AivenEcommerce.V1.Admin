
window.onSignIn = function(googleUser) {
    var profile = googleUser.getBasicProfile();
    console.log('ID: ' + profile.getId()); // Do not send to your backend! Use an ID token instead.
    console.log('Name: ' + profile.getName());
    console.log('Image URL: ' + profile.getImageUrl());
    console.log('Email: ' + profile.getEmail()); // This is null if the 'email' scope is not present.
}

window.signOut = function() {
    var auth2 = gapi.auth2.getAuthInstance();
    auth2.signOut().then(function () {
        console.log('User signed out.');
    });
}


export function main() {
    // Dropdown Sidebar Menu
    var sidebarItems = document.querySelectorAll('.sidebar-item.has-sub');

    var _loop = function _loop() {
        var sidebarItem = sidebarItems[i];
        sidebarItems[i].querySelector('.sidebar-link').addEventListener('click', function (e) {
            e.preventDefault();
            var submenu = sidebarItem.querySelector('.submenu');
            if (submenu.classList.contains('active')) submenu.classList.remove('active'); else submenu.classList.add('active');
        });
    };

    for (var i = 0; i < sidebarItems.length; i++) {
        _loop();
    } // Navbar Toggler


    var sidebarToggler = document.querySelectorAll(".sidebar-toggler");

    for (var i = 0; i < sidebarToggler.length; i++) {
        var toggler = sidebarToggler[i];
        toggler.addEventListener('click', function (e) {
            e.preventDefault();
            var sidebar = document.getElementById('sidebar');
            if (sidebar.classList.contains('active')) sidebar.classList.remove('active'); else sidebar.classList.add('active');
        });
    } // Perfect Scrollbar INit


    if (typeof PerfectScrollbar == 'function') {
        var container = document.querySelector(".sidebar-wrapper");
        var ps = new PerfectScrollbar(container);
    }


    window.onload = function () {
        var w = window.innerWidth;

        if (w < 768) {
            console.log('widthnya ', w);
            document.getElementById('sidebar').classList.remove('active');
        }
    };

    feather.replace();
}
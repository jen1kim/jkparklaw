function setDivHeight(e){var t=0;$(e).each(function(e){$(this).height()>t&&(t=$(this).height())}),$(e).height(t)}setDivHeight(".home-quicklink .item-wrapper");var d=new Date,n=d.getFullYear();document.getElementById("year").innerHTML=n;
document.addEventListener("DOMContentLoaded", function () {
  // Toggle Desktop Mega menu ( Categories )
  const desktopMegamenuWrapper = document.getElementById(
    "desktopMegamenuWrapper"
  );
  const desktopMegamenu = document.getElementById("desktopMegamenu");
  const headerOverlay = document.getElementById("header-overlay");
  let showDesktopMegamenu = false;

  if (desktopMegamenuWrapper && desktopMegamenu && headerOverlay) {
    const toggleMegamenu = (event) => {
      showDesktopMegamenu = event.type === "mouseenter";
      desktopMegamenu.classList.toggle("hidden", !showDesktopMegamenu);
      headerOverlay.classList.toggle("hidden", !showDesktopMegamenu);
    };

    desktopMegamenuWrapper.addEventListener("mouseenter", toggleMegamenu);
    desktopMegamenuWrapper.addEventListener("mouseleave", toggleMegamenu);
  }

  // Hide mobile navbar on Scroll Start
  let isSearchResultShow = false;
  const mobileHeaderBottom = document.getElementById("mobile-header-bottom");
  const desktopHeaderBottom = document.getElementById("desktop-header-bottom");
  let isScrollingDown = false;
  let prevScrollPos = window.pageYOffset || document.documentElement.scrollTop;

  if (mobileHeaderBottom && desktopHeaderBottom) {
    const handleScroll = () => {
      const currentScrollPos =
        window.pageYOffset || document.documentElement.scrollTop;

      if (currentScrollPos > 100 && currentScrollPos > prevScrollPos) {
        if (!isScrollingDown && !showDesktopMegamenu && !isSearchResultShow) {
          mobileHeaderBottom.classList.add("-translate-y-full");
          desktopHeaderBottom.classList.add("-translate-y-full");
          isScrollingDown = true;
        }
      } else {
        mobileHeaderBottom.classList.remove("-translate-y-full");
        desktopHeaderBottom.classList.remove("-translate-y-full");
        isScrollingDown = false;
      }

      prevScrollPos = currentScrollPos;
    };

    window.addEventListener("scroll", handleScroll);
  }
  // Hide mobile navbar on Scroll End

  // Desktop Header Megamenu section
  const categoriesParentsMegamenu = document.querySelectorAll(
    "#mega-menu-parents li a"
  );
  const categoriesChildsMegamenu = document.querySelectorAll(
    "#mega-menu-childs > div[data-category-child]"
  );

  if (categoriesParentsMegamenu.length > 0) {
    // Apply the classes to the first item at page load
    categoriesParentsMegamenu[0].classList.add("mega-menu-active");
    categoriesChildsMegamenu[0].classList.remove("hidden");

    categoriesParentsMegamenu.forEach((item) => {
      item.addEventListener("mouseenter", () => {
        // Remove the 'active' class from all parent categories and hide all child divs
        categoriesParentsMegamenu.forEach((otherItem) =>
          otherItem.classList.remove("mega-menu-active")
        );
        categoriesChildsMegamenu.forEach((childDiv) =>
          childDiv.classList.add("hidden")
        );

        // Add the 'active' class to the current parent category and show the corresponding child div
        item.classList.add("mega-menu-active");
        document
          .querySelector(
            `div[data-category-child="${item.getAttribute(
              "data-category-parent"
            )}"]`
          )
          .classList.remove("hidden");
      });
    });
  }
  // Border Animation Section Start
  const setMousePosition = (e) => {
    document.querySelectorAll(".border-gradient").forEach((item) => {
      const { left, top } = item.getBoundingClientRect();
      const { clientX, clientY } = e;
      item.style.setProperty("--x", `${clientX - left}px`);
      item.style.setProperty("--y", `${clientY - top}px`);
    });
  };

  document.addEventListener("mousemove", setMousePosition);

  // Border Animation Section End

  // noUiSlider Section Start

  const shopPriceSlider = document.querySelectorAll("#shop-price-slider");
  const shopPriceSliderMin = document.querySelectorAll(
      "#shop-price-slider-min"
    ),
    shopPriceSliderMax = document.querySelectorAll("#shop-price-slider-max");

  shopPriceSlider.forEach((item) => {
    noUiSlider.create(item, {
      cssPrefix: "range-slider-",
      start: [0, 100_000_000],
      direction: "rtl",
      margin: 1,
      connect: true,
      range: {
        min: 0,
        max: 100_000_000,
      },
      format: {
        to: function (value) {
          return value.toLocaleString("en-US", {
            style: "decimal",
            maximumFractionDigits: 0,
          });
        },
        from: function (value) {
          return parseFloat(value.replace(/,/g, ""));
        },
      },
    });

    item.noUiSlider.on("update", function (values, handle) {
      if (handle) {
        shopPriceSliderMax.forEach((price_item) => {
          price_item.innerHTML = values[handle];
        });
      } else {
        shopPriceSliderMin.forEach((price_item) => {
          price_item.innerHTML = values[handle];
        });
      }
    });
  });
  // noUiSlider Section End

  // Header Search Overlay Start
  function initializeSearchComponent(baseId, wrapperId, searchId, resultId) {
    const base = document.getElementById(baseId);
    const wrapper = document.getElementById(wrapperId);
    const search = document.getElementById(searchId);
    const result = document.getElementById(resultId);

    if (!base || !wrapper || !search || !result) {
      return;
    }

    function hideSearchResults() {
      wrapper.classList.remove(
        "border",
        "bg-white",
        "dark:bg-zinc-900",
        "rounded-b-none"
      );
      wrapper.classList.add("bg-gray-100", "dark:bg-black");
      search.classList.remove("bg-white", "dark:bg-zinc-900");
      search.classList.add("bg-gray-100", "dark:bg-black");
      wrapper.classList.remove("rounded-b-none");
      headerOverlay.classList.add("hidden");
      result.classList.add("hidden");
      isSearchResultShow = false;
    }

    search.addEventListener("focus", () => {
      wrapper.classList.add(
        "border",
        "bg-white",
        "dark:bg-zinc-900",
        "rounded-b-none"
      );
      wrapper.classList.remove("bg-gray-100", "dark:bg-black");
      search.classList.add("bg-white", "dark:bg-zinc-900");
      search.classList.remove("bg-gray-100", "dark:bg-black");
      headerOverlay.classList.remove("hidden");
      result.classList.remove("hidden");
      isSearchResultShow = true;
    });

    return { base, hideSearchResults };
  }

  const desktopSearchComponent = initializeSearchComponent(
    "desktopHeaderSearchBase",
    "desktopHeaderSearchWrapper",
    "desktopHeaderSearch",
    "desktopHeaderSearchResult"
  );

  const mobileSearchComponent = initializeSearchComponent(
    "mobileHeaderSearchBase",
    "mobileHeaderSearchWrapper",
    "mobileHeaderSearch",
    "mobileHeaderSearchResult"
  );

  if (desktopSearchComponent && mobileSearchComponent) {
    const { base: desktopBase, hideSearchResults: hideDesktopSearchResults } =
      desktopSearchComponent;
    const { base: mobileBase, hideSearchResults: hideMobileSearchResults } =
      mobileSearchComponent;

    // Add click event listener to the document
    document.addEventListener("mousedown", (event) => {
      if (
        desktopBase &&
        mobileBase &&
        !desktopBase.contains(event.target) &&
        !mobileBase.contains(event.target)
      ) {
        hideDesktopSearchResults();
        hideMobileSearchResults();
      }
    });
  }
  // Header Search Overlay End

  // Quiantity Input Start
  function quantityDecrement(e) {
    const btn = e.target.parentNode.parentElement.querySelector(
      'button[data-action="increment"]'
    );
    const target = btn.nextElementSibling;
    let value = Number(target.value);
    if (value == 1) return;
    value--;
    target.value = value;
  }

  function quantityIncrement(e) {
    const btn = e.target.parentNode.parentElement.querySelector(
      'button[data-action="increment"]'
    );
    const target = btn.nextElementSibling;
    let value = Number(target.value);
    value++;
    target.value = value;
  }

  const quantityDecrementButtons = document.querySelectorAll(
    `button[data-action="decrement"]`
  );

  const quantityIncrementButtons = document.querySelectorAll(
    `button[data-action="increment"]`
  );

  quantityDecrementButtons.forEach((btn) => {
    btn.addEventListener("click", quantityDecrement);
  });

  quantityIncrementButtons.forEach((btn) => {
    btn.addEventListener("click", quantityIncrement);
  });
  // Quiantity Input End
});

//////////////////////////////////////////////Timer product
document.addEventListener("readystatechange", (event) => {
  if (event.target.readyState === "complete") {
    var clockdiv = document.getElementsByClassName("clockdiv");
    var countDownDate = new Array();
    for (var i = 0; i < clockdiv.length; i++) {
      countDownDate[i] = new Array();
      countDownDate[i]["el"] = clockdiv[i];
      countDownDate[i]["time"] = new Date(
        clockdiv[i].getAttribute("data-date")
      ).getTime();
      countDownDate[i]["hours"] = 0;
      countDownDate[i]["seconds"] = 0;
      countDownDate[i]["minutes"] = 0;
    }

    var countdownfunction = setInterval(function () {
      for (var i = 0; i < countDownDate.length; i++) {
        var now = new Date().getTime();
        var distance = countDownDate[i]["time"] - now;
        countDownDate[i]["hours"] = Math.floor(
          (distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60)
        );
        countDownDate[i]["minutes"] = Math.floor(
          (distance % (1000 * 60 * 60)) / (1000 * 60)
        );
        countDownDate[i]["seconds"] = Math.floor(
          (distance % (1000 * 60)) / 1000
        );

        if (distance < 0) {
          countDownDate[i]["el"].querySelector(".hours").innerHTML = 0;
          countDownDate[i]["el"].querySelector(".minutes").innerHTML = 0;
          countDownDate[i]["el"].querySelector(".seconds").innerHTML = 0;
        } else {
          countDownDate[i]["el"].querySelector(".hours").innerHTML =
            countDownDate[i]["hours"];
          countDownDate[i]["el"].querySelector(".minutes").innerHTML =
            countDownDate[i]["minutes"];
          countDownDate[i]["el"].querySelector(".seconds").innerHTML =
            countDownDate[i]["seconds"];
        }
      }
    }, 1000);
  }
});

/////////////////////////////////// btn go to up
let mybutton = document.getElementById("btn-back-to-top");

mybutton.addEventListener("click", backToTop);

function backToTop() {
  document.body.scrollTop = 0;
  document.documentElement.scrollTop = 0;
}
//////////////////////////////////// single priduct show images
function currentDiv(n) {
  showDivs(slideIndex = n);
}

function showDivs(n) {
  var i;
  var x = document.getElementsByClassName("mySlides");
  var dots = document.getElementsByClassName("demo");
  if (n > x.length) {slideIndex = 1}
  if (n < 1) {slideIndex = x.length}
  for (i = 0; i < x.length; i++) {
    x[i].style.display = "none";
  }
  for (i = 0; i < dots.length; i++) {
    dots[i].className = dots[i].className.replace(" w3-opacity-off", "");
  }
  x[slideIndex-1].style.display = "block";
  dots[slideIndex-1].className += " w3-opacity-off";
}
setTimeout(function(){
  $('a[href*="#pizzas "]').on('click', function(e) {
      e.preventDefault();

      $('html, body').animate({
          scrollTop: $($(this).attr('href')).offset().top
      }, 500, 'linear');
  });

  var money1 = 0;
  var money2 = 0;
  var money3 = 0;
  var money4 = 0;

  $('input[name="pizzasize"]').change(function() {
      $('#money').text(this.value);

      var money = this.value;
      money = parseFloat(money.substr(1))
      $('#alfredo input')[3].value = money;
      if (money < 14){
        $('#alfredo input')[1].value = "Small"
      }
      else if (money < 23) {
        $('#alfredo input')[1].value = "Medium"
      }
      else {
        $('#alfredo input')[1].value = "Large"
      }

  })

  $('input[name="pizzasize2"]').change(function() {
      $('#money2').text(this.value);

      var money2 = this.value;
      money2 = parseFloat(money2.substr(1))
      $('#pizzapizza input')[3].value = money2;
      if (money2 < 14){
        console.log("Small")
        $('#pizzapizza input')[1].value = "Small"
      }
      else if (money2 < 23) {
        console.log("medium")
        $('#pizzapizza input')[1].value = "Medium"
      }
      else {
        console.log('Large')
        $('#pizzapizza input')[1].value = "Large"
      }
  })

  $('input[name="pizzasize3"]').change(function() {
      $('#money3').text(this.value);

      var money = this.value;
      money = parseFloat(money.substr(1))
      $('#hawai input')[3].value = money;
      if (money < 14){
        $('#hawai input')[1].value = "Small"
      }
      else if (money < 23) {
        $('#hawai input')[1].value = "Medium"
      }
      else {
        $('#hawai input')[1].value = "Large"
      }
  })


  $('input[name="pizzasize4"]').change(function() {
      $('#money4').text(this.value);

      var money = this.value;
      money = parseFloat(money.substr(1))
      $('#veggie input')[3].value = money;
      if (money < 14){
        $('#veggie input')[1].value = "Small"
      }
      else if (money < 23) {
        $('#veggie input')[1].value = "Medium"
      }
      else {
        $('#veggie input')[1].value = "Large"
      }

  })

  $(document).ready(function(){
    $('.carousel').carousel();
  });
  // var quan = $('.Quantity').text();
  // var total = $('.Subtotal').text();
  // var price = $('.Price').text()
  // var ww = price * total
  // $('.Subtotal').text(ww.toFixed(2));


},300)

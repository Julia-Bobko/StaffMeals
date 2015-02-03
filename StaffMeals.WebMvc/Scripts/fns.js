// прелоад картинок
function preload(page)
{
  if (page == 'splash')
  {
    /* Это пример прелодера картинок
    var pic_x = new Image(85, 14);
    pic_x.src = "/images/pic_x_hover.jpg";
    */
  }

  if (page == 'index')
  {
    /* Это пример прелодера картинок
    var pic_x = new Image(85, 14);
    pic_x.src = "/images/pic_x_hover.jpg";
    */
  }
}

function divided_by_3( num ){
	result = '';
	d = num % 1000;
	num = num/1000 >> 0;
	while( num > 0 ){
		result = d + result;

		if( d < 100 ){
			result = '0' + result;
		}
		if( d < 10 ){
			result = '0' + result;
		}

		result = " " + result;
		d = num % 1000;
		num = num/1000 >> 0;
	}
	
	result = d + result;
	
	return result;
}

jQuery(document).ready(function($){
  $("a.content_but_left").hover(
    function(event)
    {
      $(this).css('background', 'url(/images/content_but_left_a.png) no-repeat top left');
      $(this).find('div.content_but_right').css('background', 'url(/images/content_but_right_a.png) no-repeat top right');
      $(this).find('div.content_but_center').css('background', 'url(/images/content_but_center_a.png) repeat-x top left');

    },
    function(event)
    {
      $(this).css('background', 'url(/images/content_but_left.png) no-repeat top left');
      $(this).find('div.content_but_right').css('background', 'url(/images/content_but_right.png) no-repeat top right');
      $(this).find('div.content_but_center').css('background', 'url(/images/content_but_center.png) repeat-x top left');
    }
  );
  $(".article_table tr:even").css('background', '#e9e9e9');
  
	$(".cell_2_input").keyup(function(event){
		calculate_basket();
  });
})


// функция для отправки формы
function submit_form(id)
{
 $("#"+id+'_form').find('div:first').html('<input type="hidden" name="action" value="'+id+'" />');
 document.getElementById(id+'_form').submit();
 
  return false;
}
function contact_form(id)
{
  //$("#"+id+'_form').find('div:first').html('<input type="hidden" name="action" value="'+id+'" />');
  //document.getElementById(id+'_form').submit();
  document.getElementById(id).submit();
  return false;
}
// ставит автоматом на все ссылки blur()
function externalLinks()
{
  if (!document.getElementsByTagName) return;
  var anchors = document.links;
  for (var i=0; i < anchors.length; i++)
  {
    anchors[i].onfocus = function(e){this.blur();}
  }
}

// задает значение в Cookie
function setCookie (name, value, expires, path, domain, secure)
{
  document.cookie = name + "=" + escape(value) +
    ((expires) ? "; expires=" + expires : "") +
    ((path) ? "; path=" + path : "") +
    ((domain) ? "; domain=" + domain : "") +
    ((secure) ? "; secure" : "");
}

// получает значение Cookie
function getCookie(name)
{
  var cookie = " " + document.cookie;
  var search = " " + name + "=";
  var setStr = null;
  var offset = 0;
  var end = 0;
  if (cookie.length > 0)
  {
    offset = cookie.indexOf(search);
    if (offset != -1)
    {
      offset += search.length;
      end = cookie.indexOf(";", offset)
      if (end == -1)
      {
        end = cookie.length;
      }
      setStr = unescape(cookie.substring(offset, end));
    }
  }
  return(setStr);
}

// возвращает первую позицию элемента в строке
function strpos(haystack, needle, offset)
{
  var i = haystack.indexOf(needle, offset);
  return i >= 0 ? i : false;
}

// standart string replace functionality
function str_replace(haystack, needle, replacement) {
	var temp = haystack.split(needle);
	return temp.join(replacement);
}

// needle may be a regular expression
function str_replace_reg(haystack, needle, replacement) {
	var r = new RegExp(needle, 'g');
	return haystack.replace(r, replacement);
}

function show_message(title, text )
{
  $('#mess_text').html(text);
  $('#message').modal({overlayClose: true});
}

function show_object(id)
{
  $.modal.close();
  $('#'+id).modal({overlayClose: true});
  return false;
}

function initLeftMenu() {
	$('.sitemap_catalog_link').click(
		function() {	
		
			if($(this).next().is('.sitemap_link_drop_box')){
				$(this).toggleClass('sitemap_catalog_link_active');
				$(this).next('.sitemap_link_drop_box').toggleClass('level_2_block');
				$(this).siblings().removeClass('sitemap_catalog_link_active');
				$(this).siblings().next('.sitemap_link_drop_box').removeClass('level_2_block');
				}
			else{
				return false;
				} 
			}
		);
} 

// добавляет продукт в корзину
function add_to_basket(id, price)
{
	basket = getCookie("basket");
	if (!basket)
	{
		setCookie("basket", '', "Mon, 01-Jan-2018 00:00:00 GMT", "/");
		basket = '';
	}
	count = $('#count_'+id).val();
	if (!count) count = 1;
  
    x = strpos(' '+basket, ','+id+':');
    if (!x)
    {
	  basket = basket + ',' + id + ':' + count + ':' + price + ';';
      setCookie("basket", basket, "Mon, 01-Jan-2018 00:00:00 GMT", "/");
	  count = Number(count);
      basket_count = basket_count + count;
      basket_price = basket_price + price*count;
      add_mess = 'Товар успешно добавлен в корзину.';
    }
    else {add_mess = 'Товар уже есть в корзине.';}

  $('#b_count').html(basket_count);
  $('#b_price').html(divided_by_3(basket_price)+' р.');
  show_message('', add_mess);

  return false;
}

// удаляет продукт из корзины
function delete_from_basket(id)
{
  basket = getCookie("basket");
  list = basket.split(';');
  count = list.length;
  new_basket = '';
  for (x=0; x<count; x++)
	if (list[x] != '' && !strpos(' '+list[x], ','+id+':')) new_basket = new_basket + list[x] + ';';
		else if (list[x] != '')
		{
			$('#pr_box_'+id).remove();
			
			basket_list_count = basket_list.length;
			new_basket_list = Array();
			z = 0;
			for (y=0; y<basket_list_count; y++)
			{
				if (basket_list[y]['indexid'] != id)
				{
					new_basket_list[z] = basket_list[y];
					z = z + 1;
				}
			}
			basket_list = new_basket_list;
		}
  
  setCookie("basket", new_basket, "Mon, 01-Jan-2018 00:00:00 GMT", "/");
  if (new_basket != '') calculate_basket();
	else $('#basket_article_box').html('Корзина пуста');

  return false;
}

// пересчитывает корзину
function calculate_basket()
{
  basket_list_count = basket_list.length
  basket_count = 0;
  summa = 0;
  zakaz = '';
  for (x=0; x<basket_list_count; x++)
  {
    id = basket_list[x]['indexid'];
    kol = document.getElementById('kol_'+id).value;
	kol = Number(kol);
    basket_list[x]['kol'] = kol;
	summa_i = kol*basket_list[x]['cena'];
	$('#summ_price_'+id).html(divided_by_3(summa_i));
    summa = summa + summa_i;
	basket_count = basket_count + kol;
    zakaz = zakaz + ',' + id + ':' + kol + ':' + basket_list[x]['cena'] + ';';
  }
  setCookie("basket", zakaz, "Mon, 01-Jan-2018 00:00:00 GMT", "/");
  $('#summa_box').html(divided_by_3(summa));
  $('#b_count').html(basket_count);
  $('#b_price').html(divided_by_3(summa)+' р.');
  return false;
}

// смена банеров
/*function slider_show(number)
{
	$('#slider_'+number).fadeOut('slow', function() {
		if (number < sliders_count) number = number + 1;
			else number = 0;
		$('#slider_'+number).fadeIn('slow');
		setTimeout("slider_show("+number+")", 4000);
    });
}*/

// смена банеров
function slider_show(number)
{
	$('#slider_'+number).fadeOut('slow', function() {
		if (number < sliders_count) number = number + 1;
			else number = 0;
		$('#slider_'+number).fadeIn('slow');
		setTimeout("slider_show("+number+")", 4000);
    });
}

// показывает/скрывает фильтры
function show_filtr_box(obj)
{
	status = $('#filtr_box').css('display');
	if (status == 'none')
	{
		$('#filtr_box').slideDown('fast');
		$(obj).attr('class', 'title_catalog_link_active');
	}
	else
	{
		$('#filtr_box').slideUp('fast');
		$(obj).attr('class', 'title_catalog_link');
	}
	return false;
}

// показывает картинки в галерее
function show_gallery_pic(id)
{
	$("a[id*=gal_]").hide();
	$("#gal_"+id).show();
}
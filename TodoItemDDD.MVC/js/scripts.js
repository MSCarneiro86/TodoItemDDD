
/* SCRIPTS DO PROJETO
---------------------------------------- */

function menuCategorias()
{
	function controlMenu(obj)
	{
		var linkOpen = obj.find('h3'),
			listaItens = obj.find('.wrapMenu'),
			altura = obj.find('.wrapMenu').find('ul').innerHeight();

		linkOpen.on('click',function()
		{
			if(!obj.hasClass('opened'))
			{
				$('.mainList').removeClass('opened');
				$('.mainList .wrapMenu').stop().animate({height : 0});
				
				obj.addClass('opened');
				listaItens.stop().animate({height : altura});
			}
			else
			{
				$('.mainList').removeClass('opened');
				$('.mainList .wrapMenu').stop().animate({height : 0});
			}
		});
	}

	if( $(window).width() >= 1024 )
	{
		$('.mainList').each(function()
		{
			controlMenu( $(this) );
		});
	}
	else
	{
		$('header#mainHeader .responsive .selectCat a.selectbar').on('click',function(e)
		{
			e.preventDefault();
			$('header#mainHeader nav.options').addClass('opened');
		});

		$('header#mainHeader nav.options a.closeMenu').on('click',function(e)
		{
			e.preventDefault();
			$('header#mainHeader nav.options').removeClass('opened');
		});
	}
}

$(function()
{
	menuCategorias();

	$(window).resize(function()
	{
		menuCategorias();
	});
});
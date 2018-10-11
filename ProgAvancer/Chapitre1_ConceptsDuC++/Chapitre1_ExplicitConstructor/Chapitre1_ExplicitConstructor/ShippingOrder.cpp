#include "ShippingOrder.h"

ShippingOrder::ShippingOrder(Box a_Box, float a_ShippingPrice)
	: m_Box(a_Box)
	, m_ShippingPrice(a_ShippingPrice)
{
}

ShippingOrder::~ShippingOrder()
{
}

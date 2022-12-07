function ValidateCpf(cpf) {
	var numeros, digitos, soma, i, resultado, digitos_iguais;
	cpf = ReplaceAll(cpf, "-", "");
	cpf = ReplaceAll(cpf, ".", "");

	digitos_iguais = 1;
	if (cpf.length < 11)
		return false;
	for (i = 0; i < cpf.length - 1; i++)
		if (cpf.charAt(i) != cpf.charAt(i + 1)) {
			digitos_iguais = 0;
			break;
		}
	if (!digitos_iguais) {
		numeros = cpf.substring(0, 9);
		digitos = cpf.substring(9);
		soma = 0;
		for (i = 10; i > 1; i--)
			soma += numeros.charAt(10 - i) * i;
		resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
		if (resultado != digitos.charAt(0))
			return false;
		numeros = cpf.substring(0, 10);
		soma = 0;
		for (i = 11; i > 1; i--)
			soma += numeros.charAt(11 - i) * i;
		resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
		if (resultado != digitos.charAt(1))
			return false;
		return true;
	}
	else
		return false;
}

function ValidateCnpj(cnpj) {
	var numeros, digitos, soma, i, resultado, pos, tamanho, digitos_iguais;

	cnpj = ReplaceAll(cnpj,".", "");
	cnpj = ReplaceAll(cnpj, "/", "");
	cnpj = ReplaceAll(cnpj, "-", "");

	digitos_iguais = 1;
	if (cnpj.length < 14 && cnpj.length < 15)
		return false;
	for (i = 0; i < cnpj.length - 1; i++)
		if (cnpj.charAt(i) != cnpj.charAt(i + 1)) {
			digitos_iguais = 0;
			break;
		}
	if (!digitos_iguais) {
		tamanho = cnpj.length - 2
		numeros = cnpj.substring(0, tamanho);
		digitos = cnpj.substring(tamanho);
		soma = 0;
		pos = tamanho - 7;
		for (i = tamanho; i >= 1; i--) {
			soma += numeros.charAt(tamanho - i) * pos--;
			if (pos < 2)
				pos = 9;
		}
		resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
		if (resultado != digitos.charAt(0))
			return false;
		tamanho = tamanho + 1;
		numeros = cnpj.substring(0, tamanho);
		soma = 0;
		pos = tamanho - 7;
		for (i = tamanho; i >= 1; i--) {
			soma += numeros.charAt(tamanho - i) * pos--;
			if (pos < 2)
				pos = 9;
		}
		resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
		if (resultado != digitos.charAt(1))
			return false;
		return true;
	}
	else
		return false;
}

function ValidateCreditCard(value) {
	if (/[^0-9-\s]+/.test(value)) return false;

	var nCheck = 0, nDigit = 0, bEven = false;
	value = value.replace(/\D/g, "");

	for (var n = value.length - 1; n >= 0; n--) {
		var cDigit = value.charAt(n), nDigit = parseInt(cDigit, 10);
		if (bEven) {
			if ((nDigit *= 2) > 9) nDigit -= 9;
		}
		nCheck += nDigit;
		bEven = !bEven;
	}
	return (nCheck % 10) == 0;
}

function validateCall(field, rule, options) {
	var rules = new Array();
	rules[0] = rule;
	switch (rule) {
		case "required":
			return field.validationEngine('requiredMethod', field, rules, 0, options);
		case "cpf":
			return ValidateCpf(field.val());
		case "cnpj":
			return ValidateCnpj(field.val());
		case "creditcard":
			return ValidateCreditCard(field.val());
		default:
			rules[1] = rules[0];
			rules[0] = "custom";
			return !field.validationEngine('customRegexMethod', field, rules, 0, options);
	}
}

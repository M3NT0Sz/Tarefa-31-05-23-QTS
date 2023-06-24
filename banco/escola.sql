-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 24/06/2023 às 21:11
-- Versão do servidor: 10.4.28-MariaDB
-- Versão do PHP: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `escola`
--

-- --------------------------------------------------------

--
-- Estrutura para tabela `alunos`
--

CREATE TABLE `alunos` (
  `codigo` int(11) NOT NULL,
  `login` varchar(200) NOT NULL,
  `cpf` varchar(20) NOT NULL,
  `rg` varchar(20) NOT NULL,
  `dn` date NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Despejando dados para a tabela `alunos`
--

INSERT INTO `alunos` (`codigo`, `login`, `cpf`, `rg`, `dn`) VALUES
(5, 'kayck viado', '1234356567', '1232455656', '1994-01-11'),
(6, 'Manoela Pinha da Silveira', '123456789', '987654321', '2006-03-29'),
(7, 'Matheus Mendes', '65384738302', '53465343', '2005-08-26'),
(8, 'João Pedro Vieira Pereira', '531.123.985-5', '777555333111', '2023-05-19'),
(9, 'Arthur', '40423345602', '4954753911', '1989-01-03'),
(10, 'Jhonas', '53415223221', '5234534222', '2004-02-05'),
(11, 'papaigargantini', '213123123123', '312312312213', '2004-07-31'),
(12, 'Ronaldson Cleber da Silva', '216326727', '37378373', '2023-05-19'),
(13, 'Manueli', '234323422', '56748856', '2010-06-16'),
(14, 'Valdemir Loranto Pastro', '26232547527', '651703017527', '2023-05-19'),
(15, 'panela do brefere', '1221312321', '3123123121', '2009-07-01'),
(16, 'Professora Itamar', '987654321', '123789456', '2023-05-19'),
(17, 'Manoela PInhais da Silvana', '645764574', '312736817', '2023-05-19'),
(18, 'Jô Soares', '1312313134', '2121212121', '2023-05-19'),
(19, 'Xaolin Matador de Porco', '12332132115', '12332132115', '2023-02-01'),
(20, 'Manoelly Pinado Silver', '328272872', '782587614', '2023-05-19'),
(21, 'Jacinto Pinto', '11111111111111111111', '1111111111111111111', '1990-02-14'),
(22, 'Kleber Clementino ', '123123123', '123123123', '2023-05-19'),
(23, 'Pedro Muraro', '13598234589', '21396829663125', '2006-05-02'),
(24, 'Paulo', '2312312312321', '1231231231231', '2006-04-19'),
(25, 'Paulo Mathias', '123123123', '123123123', '2023-05-19'),
(26, 'Paula Tejando', '1111111111111111111', '1111111111111111111', '1999-06-22'),
(27, 'Maria das dores', '789654123', '741852963', '2003-09-21'),
(28, 'Garcia Giratório', '59257574', '83171331', '2023-05-19'),
(29, 'rogeio anzol da silva', '12354965485', '6.4729792.26.', '1755-07-30'),
(30, 'Emzo Baptista Calista da Silva Monteiro Ribeiro Marcio', '139685234689', '249038624096', '2022-02-02'),
(31, 'paula tegano', '2159711761', '314579129781762', '1755-07-31'),
(32, 'Ana luisa pinheiro de macedo', '1597538462', '153798264', '2020-03-21'),
(33, 'elis angela', '879173782939', '187297289462869', '1806-10-10'),
(34, 'avliS aD oriehniP aleonaM', '03546326', '123123123', '2023-05-19'),
(35, 'Enzo Pio Piolicarpio', '91386234908', '0234960249', '2000-03-30'),
(36, 'Danrã da Silva', '00011123244', '5454454554545', '1999-11-01'),
(37, 'Manoela Pinheiro Girotto', '36243543', '456453421', '2023-05-19'),
(38, 'comedor de cimento da silva', '19729286327929', '1253698725942197', '1908-05-27'),
(39, 'Policarpo Quaresma', '12312312312', '12312312312', '2004-10-13'),
(40, 'jaum', '1234567890', '4002 8922', '2023-05-19'),
(41, 'Alan Bida do Rego', '32123123123', '32112312321', '2004-10-13'),
(42, 'Anoela', '3214244243', '434223444', '2008-10-01'),
(43, 'Noela', '3129580', '0234968249068', '2000-03-30'),
(44, 'xerox da silva', '321321321', '123123123', '1999-11-03'),
(45, 'arnaldo cezar coelho', '182375412', '1234356231', '2006-06-25'),
(46, 'Oela', '24362346', '1352346423', '2000-03-30'),
(47, 'Ela', '46457', '1356246', '2000-03-30'),
(48, 'La', '13523464376', '12353463r7', '2000-03-30'),
(49, 'Ana Konda', '54353454343', '45354353434', '1999-01-28'),
(50, 'ARNALDO SACA ROLHA', '136374', '1236347', '2000-03-30'),
(51, 'tchubirau daum daum', '41877655813', '11111111111', '2020-01-16'),
(70, 'Caio Policarpo', '12348901234567890', '0987654320978654321', '2023-05-19'),
(53, 'flavin do pneu', '09812390', '213591346', '2001-06-22'),
(54, 'atebmorT rotiV oãoJ', '0500 2017 040', '4002 8722', '2023-05-19'),
(55, 'Giuseppe Cadura', '321341234', '1234123421', '1994-06-23'),
(56, 'caio pinto da suilva', '72297294', '1713694721798', '1911-12-25'),
(57, 'arieiV oãoJ', '32165498700', '55584584545454', '2000-01-01'),
(66, 'Vivara Grande', '4123211231', '1234123141', '2005-11-14'),
(59, 'Jalin Habey', '4325234123', '5123512353', '1994-10-25'),
(60, 'Brefere 02', '35356353', '234234234', '2023-05-19'),
(61, 'Jé Badura', '09808908998', '09808908908', '1999-11-04'),
(67, 'Manuzita perna cambita', '445646252', '4123423423', '2023-05-19'),
(63, 'goku baiano da silva', '57928762142179', '17897257023691', '1912-10-09'),
(64, 'ariereP arieiV ordeP oãoJ', '51 420 777 15', '12 13 14 15', '2023-05-19'),
(65, 'Manoela Garcia da Silva', '2342353543', '1231423', '2023-05-19'),
(68, 'brefere pinto', '1254123512', '1235213512', '2005-03-12'),
(69, 'Gabriel Brefere Rei das Panelas', '1352346', '3126426', '2000-03-30'),
(71, 'Caio Pinto 606', '98765432100', '545847842346947', '2001-01-02'),
(72, 'ereferB leirbaG', '22 22 22 22', '22 22 22 22', '2023-05-19'),
(73, 'Japones come molcego', '1243464614', '23423512', '2023-05-19'),
(74, 'Brefere Batistano', '342141442422', '112333211', '2000-02-17'),
(75, 'Brefere 22CM', '12345678911', '4145145214547', '2002-01-05'),
(76, 'Brefer', '34542334442', '2324421412', '2000-02-08'),
(77, 'Paula tejano', '13 13 13 13 13 13 13', '22222222222222222222', '2023-05-19'),
(78, 'Noela', '35344142', '233234234', '2023-05-19'),
(79, 'Brefere daddy', '231424422322', '53141423421', '2000-12-01'),
(80, 'Papai Brefere', '1352366', '12246346', '2000-03-30'),
(81, 'Oela', '4535353', '5345353', '2023-05-19'),
(82, 'morfeu bransco de pinha du', '12345678', '71417871258', '2023-05-19'),
(83, 'Antedeguemon', '14785236900', '32133553556', '2005-07-13'),
(84, 'Bonholesa', '342562353223', '523432432', '2000-12-06'),
(85, 'Ela', '45744124346', '234345634', '2023-05-19'),
(86, 'La', '13435345345', '234612335', '2023-05-19'),
(87, 'no cume mordem formigas', '123123123123', '456456456456', '2023-05-19'),
(88, 'AAMACEI TEU PUDIM', '42134123123', '12345123412', '2005-11-30'),
(89, 'Brefere Leite aquino rego', '8721849872173', '234574435234', '2003-02-02'),
(90, 'BOLONHESAgay', '3123123312', '1232131223', '2000-03-30'),
(91, 'Enzo Valentina', '03985323', '3688343', '1993-07-29'),
(92, 'Pay Town bank', '5544332211', '456789789', '2023-05-19'),
(93, 'Erick pega catiorro', '1534535', '13534534', '2023-05-19'),
(94, 'ARRANCA DIO (DO JOJO)', '4314124123', '4123123412', '2010-06-08'),
(95, 'Picasso Dimensional', '545602692665', '54515544051', '2006-07-27'),
(96, 'farquard concreto em pé', '15959176', '747984257193', '1991-08-10'),
(97, 'zebra listrada', '88888888', '22222222', '1998-08-31'),
(98, 'Ruela', '54564015614', '54545644564', '2008-12-10'),
(99, 'Manoela Cadastra Filho', '12312342353', '12314232', '2023-05-19'),
(100, 'breferegay', '21231321312', '32132131231', '2023-05-19'),
(101, 'Colher da Silver', '76757567657', '75675675675', '2010-07-02'),
(102, 'Brefere Coxinha', '1235347457', '12534657', '2000-03-30'),
(103, 'Simas Turbo', '000999888777', '101010292929', '2023-05-19'),
(104, 'Mimas Turbo', '02891283574107238', '81290462379', '2023-05-19'),
(105, 'shaolin matador de porco', '5165486564', '68468465', '2023-05-19'),
(106, 'authentic games', '123521356', '6234634623', '2011-12-09'),
(107, 'Lorena Andrade da Silva', '22222222', '33333333', '2020-02-07'),
(108, 'Kimetsu no seu yaiba', '45645645654', '12321312355', '2010-07-02'),
(109, 'Alan Bedoura De Pinto', '36545464484651', '2341647285634', '2023-05-19'),
(110, 'João Vitor Mama Trombeta', '645762523', '123123123', '2023-05-19'),
(111, 'Fudero Kamiyamoto', '454545454554545', '15456444445', '2008-12-10'),
(112, 'julia felicio da silva', '47722523803', '182736941', '2000-06-22'),
(113, 'Bartolomeu Dias', '48658342', '23643838', '2008-10-27'),
(122, 'everton olhares yt da silava', '1739258719', '1971913691258', '1753-01-01'),
(115, 'pastel de flannguito dela silava', '5453178', '51671342', '2000-01-23'),
(116, 'Louis  Amado Silva Camargo Silver Anjos Endiabrados', '5343673453', '4353463453', '2013-06-04'),
(117, 'Monkey D. Luffy, o próximo Rei dos Piratas', '2234034013401302414', '4515414314312541', '2010-03-29'),
(118, 'soldadinho ', '171269', '71587136', '1798-12-28'),
(119, 'Paulo Pinto de Anzol', '2512457574423', '3543543353535', '2010-03-29'),
(120, 'baleia', '00000000000', '22222222233', '1850-07-15'),
(121, 'anaconda', '12312312312', '31231231211', '2010-03-29'),
(123, 'papa americano', '89237238993', '631212126901', '1943-11-01'),
(124, 'alek pulmão limpo de silva pinto', '125712979', '925769471', '1955-11-10'),
(125, 'Pelicano fodido antissocial, com asma, bronquite e rinite', '123456789012341235', '2569045289063459624', '2023-05-19');

-- --------------------------------------------------------

--
-- Estrutura para tabela `financas`
--

CREATE TABLE `financas` (
  `fin_cod` int(11) NOT NULL,
  `fin_nome` varchar(200) NOT NULL,
  `fin_valor` float NOT NULL,
  `fin_pag` varchar(20) NOT NULL,
  `fin_data` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Despejando dados para a tabela `financas`
--

INSERT INTO `financas` (`fin_cod`, `fin_nome`, `fin_valor`, `fin_pag`, `fin_data`) VALUES
(1, 'Luz', 100, 'Sim', '2023-06-24'),
(2, 'Água', 250, 'Não', '2023-06-24'),
(3, 'Gás', 75, 'Não', '2023-02-23');

-- --------------------------------------------------------

--
-- Estrutura para tabela `professores`
--

CREATE TABLE `professores` (
  `codigo` int(11) NOT NULL,
  `nome` varchar(100) NOT NULL,
  `cpf` varchar(100) NOT NULL,
  `rg` varchar(100) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Despejando dados para a tabela `professores`
--

INSERT INTO `professores` (`codigo`, `nome`, `cpf`, `rg`) VALUES
(1, 'André Luiz Rossetti', '23132154564', '4564867321321');

-- --------------------------------------------------------

--
-- Estrutura para tabela `usuarios`
--

CREATE TABLE `usuarios` (
  `id` int(11) NOT NULL,
  `login` varchar(200) NOT NULL,
  `senha` varchar(200) NOT NULL,
  `dn` date NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Despejando dados para a tabela `usuarios`
--

INSERT INTO `usuarios` (`id`, `login`, `senha`, `dn`) VALUES
(28, 'carlos', '202CB962AC59075B964B07152D234B70', '1995-07-13'),
(29, 'renan', '202CB962AC59075B964B07152D234B70', '1995-04-28'),
(30, 'andre', '6FA5C60628804A1B10F25481C1F91165', '1980-05-16'),
(31, 'Fernanda Souza', 'E10ADC3949BA59ABBE56E057F20F883E', '2009-06-16'),
(32, 'Manu', '3C333AADFC3EE8ECB8D77EE31197D96A', '2006-03-29'),
(34, 'Matheus William', 'C052BBB5717340593167A0B360359D02', '2005-09-03'),
(35, 'João Vitor Trombeta', '6299DA3E7196F44FD742B73FE2E5EE73', '2005-08-03'),
(40, 'João Pedro Vieira Pereira', 'E10ADC3949BA59ABBE56E057F20F883E', '2005-01-25'),
(37, 'Matheus Mendes', '81DC9BDB52D04DC20036DBD8313ED055', '2005-08-26'),
(38, 'arthur@gmail.com', '9EB71AB7420EB452A22787CA4FAB501B', '2006-03-29'),
(39, 'JP1005YT', '281DEDE189CF6720C3415EC09B3BA1D5', '2006-01-04'),
(41, 'Gustavo', 'E10ADC3949BA59ABBE56E057F20F883E', '2006-03-14'),
(42, 'João Pedro Cisilo', 'E10ADC3949BA59ABBE56E057F20F883E', '2006-03-01'),
(43, 'Ian Gabriel', 'E807F1FCF82D132F9BB018CA6738A19F', '2023-05-19'),
(44, 'Paulo', '202CB962AC59075B964B07152D234B70', '2006-04-19'),
(45, 'muraro', '202CB962AC59075B964B07152D234B70', '2023-05-19'),
(46, 'rogerio anzol', 'C4CA4238A0B923820DCC509A6F75849B', '1800-07-17'),
(47, 'Brefere', 'A2EF406E2C2351E0B9E80029C909242D', '2006-02-02'),
(48, 'bonassa', '92DAA86AD43A42F28F4BF58E94667C95', '2006-02-16'),
(49, 'Camargo', '202CB962AC59075B964B07152D234B70', '2006-04-06'),
(50, 'Sophia Agosta do Nascimento', 'D0717F47123F763C266CA3A759DCAF30', '2005-06-09'),
(51, 'caio', '4C3F505126863CBD17FB1600FD044B16', '2005-11-25'),
(52, 'carimbo miguel', 'A2EF406E2C2351E0B9E80029C909242D', '2006-05-19'),
(53, 'Sophia Agosta', 'D0717F47123F763C266CA3A759DCAF30', '2020-07-22'),
(54, 'Matheus', '81DC9BDB52D04DC20036DBD8313ED055', '2005-08-26');

--
-- Índices para tabelas despejadas
--

--
-- Índices de tabela `alunos`
--
ALTER TABLE `alunos`
  ADD PRIMARY KEY (`codigo`);

--
-- Índices de tabela `financas`
--
ALTER TABLE `financas`
  ADD PRIMARY KEY (`fin_cod`);

--
-- Índices de tabela `professores`
--
ALTER TABLE `professores`
  ADD PRIMARY KEY (`codigo`);

--
-- Índices de tabela `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT para tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `alunos`
--
ALTER TABLE `alunos`
  MODIFY `codigo` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=126;

--
-- AUTO_INCREMENT de tabela `financas`
--
ALTER TABLE `financas`
  MODIFY `fin_cod` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de tabela `professores`
--
ALTER TABLE `professores`
  MODIFY `codigo` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de tabela `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=55;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

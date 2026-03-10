-- MySQL dump 10.13  Distrib 8.0.44, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: outdoor_chain_db
-- ------------------------------------------------------
-- Server version	8.0.44

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `base_products`
--

DROP TABLE IF EXISTS `base_products`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `base_products` (
  `product_id` int NOT NULL AUTO_INCREMENT COMMENT '商品ID',
  `barcode` varchar(50) COLLATE utf8mb4_general_ci NOT NULL COMMENT '条形码(扫码用)',
  `product_name` varchar(100) COLLATE utf8mb4_general_ci NOT NULL COMMENT '商品名称',
  `category` varchar(50) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '分类(如：登山鞋/冲锋衣)',
  `brand` varchar(50) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '品牌',
  `unit_price` decimal(10,2) NOT NULL COMMENT '统一零售价',
  `cost_price` decimal(10,2) DEFAULT NULL COMMENT '成本价',
  `spec` varchar(50) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '规格/尺码',
  `description` text COLLATE utf8mb4_general_ci COMMENT '商品描述',
  PRIMARY KEY (`product_id`),
  UNIQUE KEY `barcode` (`barcode`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='商品基础资料表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `base_products`
--

LOCK TABLES `base_products` WRITE;
/*!40000 ALTER TABLE `base_products` DISABLE KEYS */;
INSERT INTO `base_products` VALUES (1,'69001','北面冲锋衣XL','服装',NULL,1299.00,600.00,NULL,NULL),(2,'69002','登山杖','装备',NULL,199.00,80.00,NULL,NULL),(3,'888001','耐克跑鞋','鞋类',NULL,899.00,NULL,NULL,NULL),(4,'69003','篮球鞋','体育用品','nike',2000.00,800.00,'43',NULL),(5,'69004','羽毛球','体育用品','lining',200.00,100.00,'8',NULL),(6,'69005','洞洞鞋','服装','无',20.00,5.00,'36',NULL),(7,'69006','帐篷','户外用品','nike',2000.00,1000.00,'中',NULL),(8,'999001','示例商品-始祖鸟冲锋衣','服装','Arc\'teryx',4500.00,2800.00,'L码',NULL);
/*!40000 ALTER TABLE `base_products` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sales_order_details`
--

DROP TABLE IF EXISTS `sales_order_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sales_order_details` (
  `detail_id` int NOT NULL AUTO_INCREMENT,
  `order_id` int NOT NULL,
  `product_id` int NOT NULL,
  `quantity` int NOT NULL COMMENT '购买数量',
  `sale_price` decimal(10,2) NOT NULL COMMENT '销售单价',
  `subtotal` decimal(10,2) NOT NULL COMMENT '小计金额',
  PRIMARY KEY (`detail_id`),
  KEY `order_id` (`order_id`),
  KEY `product_id` (`product_id`),
  CONSTRAINT `sales_order_details_ibfk_1` FOREIGN KEY (`order_id`) REFERENCES `sales_orders` (`order_id`),
  CONSTRAINT `sales_order_details_ibfk_2` FOREIGN KEY (`product_id`) REFERENCES `base_products` (`product_id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='订单明细表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sales_order_details`
--

LOCK TABLES `sales_order_details` WRITE;
/*!40000 ALTER TABLE `sales_order_details` DISABLE KEYS */;
INSERT INTO `sales_order_details` VALUES (1,1,1,2,1299.00,2598.00),(2,2,2,2,199.00,398.00),(3,6,2,1,199.00,199.00),(4,8,4,1,2000.00,2000.00),(5,9,1,1,1299.00,1299.00),(6,10,3,1,449.50,449.50),(7,11,1,1,1299.00,1299.00),(8,11,2,1,199.00,199.00);
/*!40000 ALTER TABLE `sales_order_details` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sales_orders`
--

DROP TABLE IF EXISTS `sales_orders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sales_orders` (
  `order_id` int NOT NULL AUTO_INCREMENT,
  `order_no` varchar(50) COLLATE utf8mb4_general_ci NOT NULL COMMENT '订单编号(按时间生成)',
  `store_id` int NOT NULL COMMENT '发生交易的门店',
  `member_id` int DEFAULT NULL COMMENT '会员ID(可为空，散客)',
  `total_amount` decimal(10,2) NOT NULL COMMENT '订单总额',
  `actual_amount` decimal(10,2) NOT NULL COMMENT '实收金额',
  `payment_method` varchar(20) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '支付方式(微信/支付宝/现金)',
  `order_time` datetime DEFAULT CURRENT_TIMESTAMP,
  `operator_id` int DEFAULT NULL COMMENT '操作员ID',
  `status` int DEFAULT '1' COMMENT '状态：1正常, 2已退货',
  PRIMARY KEY (`order_id`),
  UNIQUE KEY `order_no` (`order_no`),
  KEY `store_id` (`store_id`),
  CONSTRAINT `sales_orders_ibfk_1` FOREIGN KEY (`store_id`) REFERENCES `sys_stores` (`store_id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='销售订单主表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sales_orders`
--

LOCK TABLES `sales_orders` WRITE;
/*!40000 ALTER TABLE `sales_orders` DISABLE KEYS */;
INSERT INTO `sales_orders` VALUES (1,'20260201170851941',1,NULL,2598.00,2598.00,'Cash','2026-02-01 17:08:51',1,1),(2,'20260204230257993',1,NULL,398.00,398.00,'Cash','2026-02-04 23:02:57',1,1),(6,'20260303000025134',1,NULL,199.00,199.00,'Cash','2026-03-03 00:00:25',1,2),(8,'20260303000118167',1,NULL,2000.00,2000.00,'Cash','2026-03-03 00:01:18',1,NULL),(9,'20260303001216758',1,NULL,1299.00,1299.00,'Cash','2026-03-03 00:12:16',1,2),(10,'20260304183029214',1,NULL,449.50,449.50,'Cash','2026-03-04 18:30:30',1,NULL),(11,'20260304224929865',1,NULL,1498.00,1498.00,'Cash','2026-03-04 22:49:29',1,NULL);
/*!40000 ALTER TABLE `sales_orders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stock_inventory`
--

DROP TABLE IF EXISTS `stock_inventory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `stock_inventory` (
  `inventory_id` int NOT NULL AUTO_INCREMENT,
  `store_id` int NOT NULL COMMENT '门店ID',
  `product_id` int NOT NULL COMMENT '商品ID',
  `quantity` int DEFAULT '0' COMMENT '当前库存数量',
  `min_threshold` int DEFAULT '5' COMMENT '库存预警阈值',
  `last_updated` datetime DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`inventory_id`),
  UNIQUE KEY `uk_store_product` (`store_id`,`product_id`),
  KEY `product_id` (`product_id`),
  CONSTRAINT `stock_inventory_ibfk_1` FOREIGN KEY (`store_id`) REFERENCES `sys_stores` (`store_id`),
  CONSTRAINT `stock_inventory_ibfk_2` FOREIGN KEY (`product_id`) REFERENCES `base_products` (`product_id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='门店库存表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stock_inventory`
--

LOCK TABLES `stock_inventory` WRITE;
/*!40000 ALTER TABLE `stock_inventory` DISABLE KEYS */;
INSERT INTO `stock_inventory` VALUES (1,1,1,97,5,'2026-03-04 22:49:29'),(2,2,1,20,5,'2026-01-29 17:08:31'),(3,1,3,99,10,'2026-03-04 18:30:29'),(4,1,2,11,10,'2026-03-04 23:17:56'),(5,1,4,100,10,'2026-03-03 00:01:18'),(6,1,5,100,10,'2026-03-03 00:00:53'),(7,1,6,113,10,'2026-03-04 22:51:19'),(8,1,7,100,10,'2026-03-03 00:01:04');
/*!40000 ALTER TABLE `stock_inventory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sys_logs`
--

DROP TABLE IF EXISTS `sys_logs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sys_logs` (
  `log_id` int NOT NULL AUTO_INCREMENT,
  `user_id` int NOT NULL COMMENT '操作人ID',
  `user_name` varchar(50) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '操作人姓名',
  `operation` varchar(50) COLLATE utf8mb4_general_ci NOT NULL COMMENT '操作类型(登录/退货/入库)',
  `details` text COLLATE utf8mb4_general_ci COMMENT '详细描述',
  `log_time` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`log_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sys_logs`
--

LOCK TABLES `sys_logs` WRITE;
/*!40000 ALTER TABLE `sys_logs` DISABLE KEYS */;
INSERT INTO `sys_logs` VALUES (1,1,'刘总','用户登录','用户 [刘总] 登录系统成功，门店ID: 1','2026-03-04 22:49:09'),(2,1,'刘总','用户登录','用户 [刘总] 登录系统成功，门店ID: 1','2026-03-04 22:51:04'),(3,1,'刘总','用户登录','用户 [刘总] 登录系统成功，门店ID: 1','2026-03-04 23:17:45'),(4,1,'刘总','商品入库','商品ID: 2, 入库数量: 1, 仓库ID: 1','2026-03-04 23:17:57'),(5,1,'刘总','用户登录','用户 [刘总] 登录系统成功，门店ID: 1','2026-03-10 16:37:23');
/*!40000 ALTER TABLE `sys_logs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sys_promotions`
--

DROP TABLE IF EXISTS `sys_promotions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sys_promotions` (
  `promo_id` int NOT NULL AUTO_INCREMENT,
  `promo_name` varchar(100) COLLATE utf8mb4_general_ci NOT NULL COMMENT '活动名称',
  `product_id` int NOT NULL COMMENT '关联商品ID',
  `discount_rate` decimal(3,2) NOT NULL COMMENT '折扣率 (0.8表示8折)',
  `start_time` datetime NOT NULL COMMENT '开始时间',
  `end_time` datetime NOT NULL COMMENT '结束时间',
  `is_active` tinyint DEFAULT '1' COMMENT '是否启用',
  `created_at` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`promo_id`),
  KEY `product_id` (`product_id`),
  CONSTRAINT `sys_promotions_ibfk_1` FOREIGN KEY (`product_id`) REFERENCES `base_products` (`product_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='促销活动表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sys_promotions`
--

LOCK TABLES `sys_promotions` WRITE;
/*!40000 ALTER TABLE `sys_promotions` DISABLE KEYS */;
INSERT INTO `sys_promotions` VALUES (1,'促销',3,0.50,'2026-03-04 18:29:24','2026-07-04 18:29:23',1,NULL);
/*!40000 ALTER TABLE `sys_promotions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sys_stores`
--

DROP TABLE IF EXISTS `sys_stores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sys_stores` (
  `store_id` int NOT NULL AUTO_INCREMENT COMMENT '门店ID',
  `store_name` varchar(100) COLLATE utf8mb4_general_ci NOT NULL COMMENT '门店名称',
  `store_type` enum('Headquarters','Branch') COLLATE utf8mb4_general_ci DEFAULT 'Branch' COMMENT '类型：总部/分店',
  `address` varchar(200) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '地址',
  `phone` varchar(20) COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT '联系电话',
  `created_at` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`store_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='门店基础信息表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sys_stores`
--

LOCK TABLES `sys_stores` WRITE;
/*!40000 ALTER TABLE `sys_stores` DISABLE KEYS */;
INSERT INTO `sys_stores` VALUES (1,'广州天河旗舰店','Headquarters','广州市天河区天河路1号',NULL,'2026-01-29 17:08:31'),(2,'佛山禅城分店','Branch','佛山市禅城季华路88号',NULL,'2026-01-29 17:08:31');
/*!40000 ALTER TABLE `sys_stores` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sys_users`
--

DROP TABLE IF EXISTS `sys_users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sys_users` (
  `user_id` int NOT NULL AUTO_INCREMENT COMMENT '用户ID',
  `username` varchar(50) COLLATE utf8mb4_general_ci NOT NULL COMMENT '登录账号',
  `password` varchar(100) COLLATE utf8mb4_general_ci NOT NULL COMMENT '加密密码',
  `real_name` varchar(50) COLLATE utf8mb4_general_ci NOT NULL COMMENT '真实姓名',
  `role` enum('Admin','Manager','Cashier') COLLATE utf8mb4_general_ci NOT NULL COMMENT '角色：超管/店长/收银员',
  `store_id` int NOT NULL COMMENT '所属门店ID',
  `status` tinyint DEFAULT '1' COMMENT '状态：1启用 0禁用',
  PRIMARY KEY (`user_id`),
  UNIQUE KEY `username` (`username`),
  KEY `store_id` (`store_id`),
  CONSTRAINT `sys_users_ibfk_1` FOREIGN KEY (`store_id`) REFERENCES `sys_stores` (`store_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='系统用户表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sys_users`
--

LOCK TABLES `sys_users` WRITE;
/*!40000 ALTER TABLE `sys_users` DISABLE KEYS */;
INSERT INTO `sys_users` VALUES (1,'admin','123456','刘总','Admin',1,1),(2,'cashier01','123456','张三','Cashier',2,1);
/*!40000 ALTER TABLE `sys_users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vip_members`
--

DROP TABLE IF EXISTS `vip_members`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `vip_members` (
  `member_id` int NOT NULL AUTO_INCREMENT,
  `card_number` varchar(50) COLLATE utf8mb4_general_ci NOT NULL COMMENT '会员卡号',
  `member_name` varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  `phone` varchar(20) COLLATE utf8mb4_general_ci NOT NULL,
  `points` int DEFAULT '0' COMMENT '当前积分',
  `balance` decimal(10,2) DEFAULT '0.00' COMMENT '储值余额',
  `level` varchar(20) COLLATE utf8mb4_general_ci DEFAULT '普通会员' COMMENT '会员等级',
  `register_date` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`member_id`),
  UNIQUE KEY `card_number` (`card_number`),
  UNIQUE KEY `phone` (`phone`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='会员档案表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vip_members`
--

LOCK TABLES `vip_members` WRITE;
/*!40000 ALTER TABLE `vip_members` DISABLE KEYS */;
INSERT INTO `vip_members` VALUES (1,'VIP8888','李四','13800138000',100,0.00,'普通会员','2026-01-29 17:08:31'),(2,'13672945116','zzzzzj','13672945116',0,0.00,'黄金会员','2026-03-03 00:59:12');
/*!40000 ALTER TABLE `vip_members` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-03-10 21:12:40
